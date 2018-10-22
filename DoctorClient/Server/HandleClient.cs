using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Sockets;
using Newtonsoft.Json.Linq;
using Utils.Connection;
using Utils.Credentials;
using System.IO;
using System.Linq;
using Utils.Model;
using System.Globalization;
using Utils;
using System.Numerics;
using Server.Exercise;
using Server.Exercise.State;

namespace Server
{
	/// <summary>
	/// For every client that connects a new object of this class will be made.
	/// </summary>
	class HandleClient
	{
		public string Name { get; set; }
		public TcpClient Client { get; set; }
		private NetworkStream Stream;
		private Patient patient;
		private TrainingSession trainingSession;
		private Dictionary<string, HandleClient> clientList;
		private bool sessionStarted;
        private bool dataSaved;
		private string sessionStartTime;
		private int trainingDurationInSec;
		private Patient patientOnMachine;
		private string nameOfPatient;
		private string machine;
		private string date;
		private JsonConnector jsonConnector;
		private int IndexOfPatient;
		private List<Patient> patients;
        private Context exercise;

		/// <summary>
		/// The constructor of HandleAClient
		/// </summary>
		/// <param name="client">The standard TCP client of C#</param>
		/// <param name="clients">A Dictionary which holds all of the clients together and the key is the machinename</param>
		public HandleClient(TcpClient client, Dictionary<string, HandleClient> clients, List<Patient> patients)
		{
			this.Client = client;
			if (clientList == null)
			{
				this.clientList = clients;
			}
			else
			{
				this.clientList.Concat(clients);
			}
			this.patients = patients;
			this.jsonConnector = new JsonConnector();
            this.dataSaved = true;
            this.sessionStarted = false;
        }

		/// <summary>
		/// The method that will be launched by the thread. It also hold all of the logic of the HandleClient class.
		/// </summary>
		public void Run()
		{
			this.Stream = Client.GetStream();
			bool done = false;

			while (!done)
			{
				string nonCheckedString = ConnectionUtils.ReadMessage(this.Stream);
				if (!string.IsNullOrEmpty(nonCheckedString))
				{
					dynamic jsonReceive = JsonConvert.DeserializeObject(nonCheckedString);
					string id = jsonReceive.id;

					switch (id)
					{
						case "AddClient":
							CheckName(jsonReceive);
							Console.WriteLine("Accepted client: {0}, Name: {1}", DateTime.Now, this.Name);
							break;
						case "AddUser":
							AddPatient(jsonReceive);
							break;
						case "Bike":
							AddDataBikeInfo(jsonReceive);
							break;
						case "Change":
							SendChange(jsonReceive);
							break;
                        case "ChangeTime":
                            SendChange(jsonReceive);
                            break;
                        case "ChangePower":
                            SendChange(jsonReceive);
                            break;
						case "PersonalMessage":
							string name = jsonReceive.name;
							NetworkStream streamP = clientList[name].Stream;
							string messageP = jsonReceive.message;
							string json = jsonConnector.getJson(jsonConnector.SendMessage(messageP));
							ConnectionUtils.SendMessage(streamP, json);
							break;
						case "EmergencyStop":
							string name2 = jsonReceive.name;
							NetworkStream streamES = clientList[name2].Stream;
							string json2 = jsonConnector.getJson(jsonReceive);
							ConnectionUtils.SendMessage(streamES, json2);
							break;
						case "Login":
							CheckLogin(jsonReceive);
							break;
						case "StartSession":
							clientList[machine].StartSession(jsonReceive, this.date, this.nameOfPatient);
							break;
						case "AccesHistory":
							Console.WriteLine(jsonReceive);
							SendHistory(jsonReceive);
							break;
						case "AddPatient":
							AddPatient(jsonReceive);
							break;
						case "Combo":
							Combine(jsonReceive);
							break;
						case "PatientNames":
                            this.patients = JsonConvert.DeserializeObject<List<Patient>>(jsonReceive.data.ToString());
							File.WriteAllText("../../res/PatientData.json", JsonConvert.SerializeObject(this.patients));
							break;
                        case "StartAstrand":
                            string AaName = jsonReceive.name;
                            Patient p = jsonReceive.patient.ToObject<Patient>();
                            Server.StartAstrand(machine, p, clientList[AaName].Stream, clientList["doctor"].Stream);
                            break;
					}
				}
			}
			RemoveName();
			this.Client.Close();
			Console.WriteLine("Client {0} closed", this.Name);
			this.Stream.Close();
			Console.WriteLine("Networkstream closed of client {0}", this.Name);
		}

		private void Combine(dynamic jsonReceive)
		{
			foreach (Patient patient in this.patients)
			{
				if (patient.name == jsonReceive.patient.ToString() && patient.date == jsonReceive.date.ToString())
				{
					this.machine = jsonReceive.machine;
					this.nameOfPatient = jsonReceive.patient;
					this.date = jsonReceive.date;
				}
			}
		}

		private void Broadcast(dynamic jsonRecieve)
		{
			string message = jsonRecieve.message;
			string json = jsonConnector.getJson(jsonConnector.SendMessage(message));
			foreach (KeyValuePair<string, HandleClient> client in clientList)
			{
				ConnectionUtils.SendMessage(client.Value.Client.GetStream(), json);
				Console.WriteLine("sends broadcast");
			}
		}

		public void SendHistory(dynamic jsonReceive)
		{
            string patientName = jsonReceive.info.name;
            string filepath = "../../res/AstrandSession.json";
            dynamic json = File.ReadAllText(filepath);
            dynamic list = JsonConvert.DeserializeObject(json);


            List<AstrandSession> Sessions = list.ToObject<List<AstrandSession>>();
            List<AstrandSession> SelectedSession = new List<AstrandSession>();

            Console.WriteLine("LIST");
            foreach (AstrandSession session in Sessions)
            {
                Console.WriteLine(session.ToString());
                if(session.name == patientName)
                {
                    SelectedSession.Add(session);
                }
            }
            Console.WriteLine("SELECTED LIST");
            foreach (AstrandSession ses in SelectedSession)
            {
                Console.WriteLine(ses.ToString());
            }
            string js = JsonConvert.SerializeObject(SelectedSession);
            ConnectionUtils.SendMessage(this.Stream, this.jsonConnector.getJson(this.jsonConnector.sendHistoryData(js)));
        }



		private void StartSession(dynamic jsonReceive, string date, string nameOfPatient)
        { 
			if (!sessionStarted)
			{
				this.trainingDurationInSec = jsonReceive.duration;
				this.sessionStarted = true;
				this.dataSaved = false;
                this.date = date;
                this.nameOfPatient = nameOfPatient;
                this.trainingSession = new TrainingSession(DateTime.Now);
                ConnectionUtils.SendMessage(this.Client.GetStream(), JsonConvert.SerializeObject(this.jsonConnector.SendChange(secondsTommss(trainingDurationInSec),0,100,"OwO")));
            }

		}

        private string secondsTommss(int seconds)
        {
            return ((seconds - seconds % 60) / 60).ToString("00") + (seconds % 60).ToString("00");
        }


        private int mmssToseconds(string mmss)
		{
			int seconds = 0;
			seconds += Convert.ToInt32(mmss.Substring(mmss.Length - 2, 2));
			seconds += Convert.ToInt32(mmss.Substring(0, 2)) * 60;
			return seconds;
		}

		private void CheckLogin(dynamic jsonReceive)
		{
			BigInteger username = jsonReceive.username;
			BigInteger password = jsonReceive.password;
			bool acces = Verify(username, password);
			if (acces)
			{
				ConnectionUtils.SendMessage(this.Stream, this.jsonConnector.getJson(this.jsonConnector.LoginResponse(true)));
				Console.WriteLine("Acces granted");
			}
			else
			{
				ConnectionUtils.SendMessage(this.Stream, this.jsonConnector.getJson(this.jsonConnector.LoginResponse(false)));
				Console.WriteLine("Acces denied");
			}

		}



		/// <summary>
		/// NOT DONE YET
		/// This method will add a patient the client
		/// </summary>
		/// <param name="jsonRecieve">The json that is recieved from the bike client</param>
		private void AddBike(dynamic jsonRecieve)
		{
			this.clientList.Add(this.Name, this);
			this.Name = jsonRecieve.name;
			string id = jsonRecieve.id;
			ConnectionUtils.SendMessage(this.Client.GetStream(), "Client added");

		}


		/// <summary>
		/// Send changes made by the doctor a bike client
		/// </summary>
		/// <param name="jsonRecieve">The json which need to be send to a client</param>
		private void SendChange(dynamic jsonRecieve)
		{
			string name = jsonRecieve.name;
			string json = JsonConvert.SerializeObject(jsonRecieve);
			NetworkStream stream = this.clientList[name].Client.GetStream();
			if (stream != null)
			{
				ConnectionUtils.SendMessage(stream, json);
			}
		}


		/// <summary>
		///  Add data from the bike Handletheclient
		/// </summary>
		/// <param name="jsonRecieve">The json recieved from the client's bike</param>
		private void AddDataBikeInfo(dynamic jsonRecieve)
        {
            string name = jsonRecieve.name;
            if (Server.exercise != null && Server.exercise.State.MachineName == name && Server.exercise.State.AllowData) 
            {
                string time = jsonRecieve.data.time;
                int pulse = jsonRecieve.data.pulse;
                int rpm = jsonRecieve.data.RPM;
                Server.exercise.State.Pulse = jsonRecieve.data.pulse;
                Console.WriteLine("RPM" + rpm);
                Server.exercise.State.Rpm = rpm;
                if (Server.exercise.State is TrainingState)
                {
                    Server.exercise.State.CheckRPM();
                }
            }
			string doctorId = "doctor";
			string json = JsonConvert.SerializeObject(jsonRecieve);
			if (this.clientList.ContainsKey(doctorId) && Server.exercise != null && Server.exercise.State.AllowData)
			{
				NetworkStream doctorStream = this.clientList[doctorId].Stream;
				ConnectionUtils.SendMessage(doctorStream, json);
			}
		}

		/// <summary>
		/// Remove the client when a client disconnects
		/// </summary>
		private void RemoveName()
		{
			this.clientList.Remove(this.Name);
		}

		/// <summary>
		/// Check if a name already exits and adds a client
		/// </summary>
		/// <param name="jsonRecieve">The json which is recieved from the client</param>
		private void CheckName(dynamic jsonRecieve)
		{

			string id = jsonRecieve.id;
			Boolean doctor = jsonRecieve.doctor;
			this.Name = jsonRecieve.name;
			dynamic json = new JObject();

			json.id = "Ack";
			string convert = JsonConvert.SerializeObject(json);
			if (!doctor)
			{
				if (clientList == null)
				{
					clientList = new Dictionary<string, HandleClient>();
				}
				this.clientList.Add(this.Name, this);
				ConnectionUtils.SendMessage(this.Client.GetStream(), convert);
				if (this.clientList.ContainsKey("doctor"))
					SendNameToDoctor(Name);

			}
			else
			{
				this.clientList.Add("doctor", this);
				SendNames(json);
			}
		}

		/// <summary>
		/// patient names needs to be made
		/// </summary>
		/// <param name="json"></param>
		private void SendNames(dynamic json)
		{
			string[] names = new string[clientList.Count];
			Patient[] patientNames = new Patient[patients.Count];
			int i = 0;
			foreach (KeyValuePair<string, HandleClient> client in clientList)
			{
				{
					names[i] = client.Key;
					i++;
				}
			}
			i = 0;
			foreach (Patient p in patients)
			{
				patientNames[i] = p;
				i++;
			}
			ConnectionUtils.SendMessage(this.Client.GetStream(), jsonConnector.getJson(jsonConnector.SendNames(names, patientNames)));
		}

		private void SendNameToDoctor(string name)
		{
			dynamic json = new JObject();
			json.id = "SendNewName";
			json.name = name;
			dynamic message = JsonConvert.SerializeObject(json);
			ConnectionUtils.SendMessage(this.clientList["doctor"].Stream, message);
		}

		private void AddToPatient()
		{
			this.patient.TrainingSessions.Add(trainingSession);
		}

		private void SaveSessionInFile()
		{
			string fromFile;

			fromFile = System.IO.File.ReadAllText($"../../res/trainingsessions/{this.date}-{this.nameOfPatient}.json");

			patient = JsonConvert.DeserializeObject<Patient>(fromFile);

            if(patient == null)
            {
                patient = new Patient();
            }
            patient.TrainingSessions.Add(trainingSession);
			string json = JsonConvert.SerializeObject(patient);
			System.IO.File.WriteAllText($"../../res/trainingsessions/{this.date}-{this.nameOfPatient}.json", json);
		}


		private void AddPatient(dynamic jsonRecieve)
		{
            Patient patientInfo = JsonConvert.DeserializeObject<Patient>(jsonRecieve.patientInfo.ToString());
            string jsonInfo = JsonConvert.SerializeObject(patientInfo);
            string date = patientInfo.date;
            string[] splitted = date.Split(@"/".ToCharArray());
            Console.WriteLine(splitted.Length);
            string year = splitted[2];
            string month = splitted[0];
            if (month.Length == 1)
            {
                month = "0" + month;
            }
            string day = splitted[1];
            if (day.Length == 1)
            {
                day = "0" + day;
            }
            date = day + "." + month + "." + year;

            File.WriteAllText($"../../res/trainingsessions/{date}-{patientInfo.name}.json", jsonInfo);

			string fromFile;

			fromFile = System.IO.File.ReadAllText("../../res/PatientData.json");

			this.patients = JsonConvert.DeserializeObject<List<Patient>>(fromFile);

            this.patients.Add(patientInfo);

			string json = JsonConvert.SerializeObject(this.patients);
			File.WriteAllText("../../res/PatientData.json", json);
		}

        public bool Verify(BigInteger username, BigInteger password)
        {
            string fromFile = System.IO.File.ReadAllText($"../../res/log.txt");
            string jsonDecrypted = StringCipher.Decrypt(BigInteger.Parse(fromFile), "ACHTENNEN");
            LoginStorage loginStorage = JsonConvert.DeserializeObject<LoginStorage>(jsonDecrypted);

            if (loginStorage.Storage.ContainsKey(StringCipher.Decrypt(username, "ACHTENNEN")) && loginStorage.Storage[(StringCipher.Decrypt(username, "ACHTENNEN"))] == StringCipher.Decrypt(password, "ACHTENNEN"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}