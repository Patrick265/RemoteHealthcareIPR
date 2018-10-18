using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Reflection.Emit;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;
using Utils.Connection.Client;
using Utils.Connection;
using Label = System.Windows.Forms.Label;
using Newtonsoft.Json.Linq;
using Utils.Model;
using Utils.Credentials;

namespace DoctorClient
{
    /// <summary>
    /// This class represents the doctor and is able to send requests to Clientbikes
    /// </summary>
    public class ClientDoctor
    {
        private Client client;
        public AvansAstrand AvansAstrand { get; set; }
        public NetworkStream stream { get; set; }
        JsonConnector jc = new JsonConnector();
        private Label errorLabel;
        private LoginForm login;
        private Form1 form;
        public List<string> machineNames;
        private List<Patient> patientNames;
        public Patient patient { get; set; }

        private RootObjectSendBikeInfo _bikeData;
        public event EventHandler bikeDataChanged;

        public void ServerConnect(LoginForm login)
        {
            TcpClient client = new TcpClient(
        //Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString()
        //"145.49.14.53"
        GlobalData.ClientDoctorIP
        , GlobalData.Port);
            stream = client.GetStream();
            this.login = login;
            Thread thread = new Thread(new ThreadStart(MethodThread));
            thread.Start();
            Console.WriteLine("Send json");
            if (errorLabel == null)
            {
                errorLabel = login.errorLabel;
            }
        }

        public void SendUsers(List<Patient> patients)
        {
            dynamic json = this.jc.getJson(this.jc.AddPatientNames(patients));
            SendToServer(json);
        }

        public void SendToServer(string msg)
        {
            ConnectionUtils.SendMessage(stream, msg);
        }



        /// <summary>
        /// This method is running the thread started by the ServerConnect() method
        /// It listens to incoming messages and enters the switch case which switches on the id from the message
        /// </summary>
        public void MethodThread()
        {
            Console.WriteLine("started listening");
            Boolean connected = false;
            while (!connected)
            {
                dynamic jsonReceive = JsonConvert.DeserializeObject(ConnectionUtils.ReadMessage(stream));
                string id = jsonReceive.id;
                switch (id)
                {
                    case "LoginResponse":
                        Boolean response = jsonReceive.response;
                        if (!response)
                        {
                            errorLabel.Invoke(new MethodInvoker(delegate
                            {
                                errorLabel.Text = "The credentials you supplied were not correct.";
                            }));
                        }
                        else
                        {
                            Thread t = new Thread(new ThreadStart(ThreadProc));
                            t.Start();
                            login.Invoke(new MethodInvoker(delegate { login.Close(); }));
                            connected = true;
                            SendAdd();
                        }
                        break;
                }
            }
            Boolean finished = false;
            while (!finished)
            {
                dynamic jsonReceive = JsonConvert.DeserializeObject(ConnectionUtils.ReadMessage(stream));
                string id = jsonReceive.id;
                switch (id)
                {
                    case "Ack":
                        Console.WriteLine("Bike added");
                        Console.WriteLine(jsonReceive);
                        List<string> bikeNames = GetBikeNames(jsonReceive);
                        Console.WriteLine("BIKENAMES: " + bikeNames.Count);
                        patientNames = GetPatientNames(jsonReceive);
                        Console.WriteLine("AANTAL PATIENTEN: " + patientNames.Count);
                        if (machineNames == null)
                        {
                            machineNames = new List<string>();
                            machineNames = bikeNames;
                        }
                        else
                        {
                            machineNames.Concat(bikeNames);
                        }
                        Form1.patients = patientNames;
                        Form1.getNames();
                        Console.WriteLine("IS FORM NULL: " + form == null);

                        Thread t2 = new Thread(new ThreadStart(StartUpdate));
                        t2.Start();
                        break;
                    case "PatientNames":
                        Console.WriteLine("PATIENTS: " + jsonReceive);
                        this.patientNames = GetPatientNames(jsonReceive);
                        this.patientNames.Concat(patientNames);
                        foreach(Patient patient in this.patientNames)
                        {
                            Console.WriteLine(patient.age.ToString());
                        }
                        break;
                    case "SendNewName":
                        string newClient = jsonReceive.name;
                        Console.WriteLine("name: " + newClient);
                        if (machineNames == null)
                        {
                            machineNames = new List<string>();
                            machineNames.Add(newClient);
                        }
                        else
                        {
                            machineNames.Add(newClient);
                        }
                        if (form != null)
                        {
                            Console.WriteLine("updated");
                            form.Invoke((MethodInvoker)delegate () {
                                form.UpdateForm(machineNames, patientNames);
                                Console.WriteLine("BIKENAMES: " + machineNames.Count);
                            });
                        }
                        break;
                    case "Bike":
                        JObject data = (JObject)jsonReceive;
                        bikeInfoData = data.ToObject<RootObjectSendBikeInfo>();
                        if (AvansAstrand != null)
                        {
                            AvansAstrand.FillChart();
                        }
                        //Console.WriteLine(bikeInfoData.data);
                        break;
                    case "HistoryData":
                        SetHistoryData(jsonReceive);
                        break;
                    case "Astrand":
                        string AInfo = jsonReceive.info;
                        string AName = jsonReceive.name;
                        AvansAstrand.SetInfo(AInfo, AName);
                        break;

                }
            }
        }

        public void Update()
        {
            form.Invoke((MethodInvoker)delegate () {
                form.UpdateForm(machineNames, patientNames);
                Console.WriteLine("BIKENAMES: " + machineNames.Count);
            });
        }

        public void GetOldData(string patientName)
        {
            Patient p = SearchPatient(patientName);
            dynamic json = jc.getJson(jc.AccesHistory(p));
            Console.WriteLine("JSON: " + json);
            SendToServer(json);
        }

        public Patient SearchPatient(string name)
        {
            foreach (Patient p in patientNames)
            {
                if (p.name == name)
                    return p;
            }
            return null;
        }

        private void StartUpdate()
        {
            while (form == null) { }
            Thread.Sleep(200);
            form.Invoke((MethodInvoker)delegate () {
                form.UpdateForm(machineNames, patientNames);
            });
        }

        private List<string> GetBikeNames(dynamic json)
        {
            List<string> names = new List<string>();
            string[] array = json.names.ToObject<string[]>();
            for (int i = 0; i < array.Count(); i++)
            {
                Console.WriteLine("array check: " + array[i]);
                if (array[i] != "doctor")
                    names.Add(array[i]);
            }
            return names;
        }

        private List<Patient> GetPatientNames(dynamic json)
        {
            return JsonConvert.DeserializeObject<List<Patient>>(json.patientnames.ToString());
        }

        public void ThreadProc()
        {
            patient = new Patient();
            form = new Form1(this, patient);
            login = null;

            Application.Run(form);
        }

        public void ChangeValues()
        {
        }
        /// <summary>
        /// Broadcast a message to every machine
        /// </summary>
        /// <param name="message">The message you want to send</param>
        public void BroadcastMessage(string message)
        {
            dynamic json = jc.getJson(jc.BroadcastMessage(message));
            SendToServer(json);
        }

        /// <summary>
        /// Broadcasts a personal message to a specific machine
        /// </summary>
        /// <param name="message">The message you want to send</param>
        /// <param name="name">The machine name you want to send it to</param>
        public void BroadcastPersonalMessage(string message, string name)
        {
            dynamic json = jc.getJson(jc.PersonalMessage(message, name));
            SendToServer(json);
        }

        /// <summary>
        /// sends an command for an emergency stop to the client
        /// </summary>
        /// <param name="name">The machine name you want to send it to</param>
        public void SendEmergencyStop(string name)
        {
            dynamic json = jc.getJson(jc.EmergencyStop(name));
            SendToServer(json);
        }

        public void StartAvansTest(string name, Patient patient)
        {
            dynamic json = jc.getJson(jc.StartAvansTest(name, patient));
            SendToServer(json);
        }

        public void SendCombo(string machine, string patient, string date)
        {
            dynamic json = jc.getJson(jc.SendCombo(machine, patient, date));
            SendToServer(json);
            Console.WriteLine("TO SERVER: " + json);
        }

        /// <summary>
        /// Sends the info from the bike to the server
        /// </summary>
        public void SendBikeInfo(int speed, double distance, int power, int rqPower, string time, int RPM, int pulse, string energy)
        {
            dynamic json = jc.getJson(jc.SendBikeInfo(speed, distance, power, rqPower, time, RPM, pulse, energy));
            SendToServer(json);
        }

        /// <summary>
        /// This method is called when the ClientBike is ready to get added into the servers program. 
        /// (Nedds to be called before you want to start sending updates)
        /// </summary>
        public void SendAdd()
        {
            dynamic json = jc.getJson(jc.Connect(true));
            SendToServer(json);
        }

        public void SendChange(string name)
        {
            dynamic json = jc.getJson(jc.SendChange("0600", 100, 20, name));
            SendToServer(json);
        }

        public void SendChangeRequest(string time, double distance, string name, int power)
        {
            dynamic json = jc.getJson(jc.SendChange(time, distance, power, name));
            SendToServer(json);
        }

        public void SendChangePower(int power, string name)
        {
            dynamic json = jc.getJson(jc.SendChangePower(name, power));
            SendToServer(json);
        }

        public void SendChangeTime(string time, string name)
        {
            dynamic json = jc.getJson(jc.SendChangeTime(time, name));
            SendToServer(json);
        }

        public void SendLoginInfo(String username, String password)
        {

            dynamic json = jc.getJson(jc.Login(StringCipher.Encrypt(username, "ACHTENNEN"), StringCipher.Encrypt(password, "ACHTENNEN")));
            Console.WriteLine(json);
            ConnectionUtils.SendMessage(this.stream, json);
        }

        public RootObjectSendBikeInfo bikeInfoData
        {
            get
            {
                return _bikeData;
            }
            set
            {
                //#3
                _bikeData = value;
                OnBikeDataChanged();
            }
        }

        protected virtual void OnBikeDataChanged()
        {
            if (bikeDataChanged != null) bikeDataChanged(_bikeData, EventArgs.Empty);
        }




        public Patient AddPatient(string name, float weight, int height, String date, bool male)
        {
            Patient patient = new Patient();
            patient.name = name;
            patient.weight = weight;
            patient.height = height;
            patient.date = date.ToString();
            patient.male = male;
            dynamic json = jc.getJson(jc.AddPat(patient));

            ConnectionUtils.SendMessage(this.stream, json);

            return patient;
        }

        public void StartSession(int seconds)
        {
            dynamic json = jc.getJson(jc.StartSes(seconds));
            ConnectionUtils.SendMessage(this.stream, json);
        }

        public void SetHistoryData(dynamic jsonReceive)
        {
            string json = jsonReceive.json;
            patient = JsonConvert.DeserializeObject<Patient>(json);
            form.bc.patient = patient;
        }


    }
}
