using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Windows.Forms;
using Utils.Connection.Client;
using BikeClient;

namespace BikeClient
{
    public partial class SimulatorGUI : Form
    {
        static IBicycle bicycle;
        public static bool emergencyStop = false;

        private System.Windows.Forms.Timer timer1;
        private JsonConnector jsonConnector;
        private Dictionary<String, String> dict = new Dictionary<string, string>();
        private String dest = "";
        public static string tempMessage;
        private Client client;
        private ClientBike cb;
        private int oldResultS = 99;
        private int oldResultM = 99;
        private bool finished = false;
        private double lastX = 0;
        private double lastY = 0;
        private double lastZ = 0;
        private static bool isDoctorOverwrite = false;

        public SimulatorGUI()
        {
            client = Program.client;
            jsonConnector = Program.jsonConnector;
            dest = Program.dest;
            InitializeComponent();

            //Tunnelid is een json en daaruit moet de id nog uit gehaald worden
            //Console.WriteLine(dest);

            String[] ArrayComPortsNames = null;
            int index = -1;
            String ComPortName = null;

            ArrayComPortsNames = SerialPort.GetPortNames();
            do
            {
                if (ArrayComPortsNames.Length == 0) break;
                index += 1;
                cmbPorts.Items.Add(ArrayComPortsNames[index]);
            }
            while (!((ArrayComPortsNames[index] == ComPortName)
                  || (index == ArrayComPortsNames.GetUpperBound(0))));

            Array.Sort(ArrayComPortsNames);
            cmbPorts.Items.Add("Simulator");
            cmbPorts.SelectedIndex = 0;

            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(Timer1_Tick);
            timer1.Interval = 1000; // in miliseconds
            timer1.Start();

            //Make the clientSide for the Bike
            
            cb = new BikeClient.ClientBike();
            cb.ServerConnect();
            cb.SendAdd();
        }

        public void ShowMessage() => txbJSON.Text = tempMessage;

        public static void ChangeBikeValues(int requestedPower) => bicycle.RequestPower(requestedPower, emergencyStop);

        public static void ChangeBikeValues(int distance, int requestedPower, string time)
        {
            isDoctorOverwrite = true;
            bicycle.RequestPower(requestedPower, emergencyStop);
            bicycle.RequestDistance(distance);
            bicycle.RequestTime(time);
        }

        void Connect()
        {
            try
            {
                if ((String)cmbPorts.SelectedItem != "Simulator")
                {
                    if (bicycle != null) bicycle.Disconnect();
                    bicycle = new Bicycle(cmbPorts.SelectedItem.ToString());
                }
                else
                {
                    if (bicycle != null) bicycle.Disconnect();
                    bicycle = new Simulator(300);
                    
                }

                bicycle.ResetDevice();
                bicycle.RequestCommandMode();
                bicycle.RequestTime("0705");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void CmbPorts_SelectedIndexChanged(object sender, EventArgs e) => Connect();

        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Thread thread = new Thread(new ThreadStart
            (delegate ()
            {
                lock (dict)
                {
                    dict = bicycle.RequestStatus();
                    this.Invoke(new MethodInvoker(delegate
                    {
                        lblDistance.Text = $"{Convert.ToInt32(dict["distance"]) / 10.0} km";
                        lblRequestedPower.Text = $"{Convert.ToInt32(dict["requested_power"])} W";
                        lblTime.Text = $"{dict["mmss"]}";
                        lblPower.Text = $"{dict["actual_power"]}";
                        lblPulse.Text = $"{dict["pulse"]}";
                        lblRPM.Text = $"{dict["rpm"]}";
                        lblSpeed.Text = $"{Convert.ToInt32(dict["speed"]) / 10.0} km/h";
                        lblEnergy.Text = $"{dict["energy"]} W";
                        ShowMessage();
                    }));
                    cb.SendBikeInfo(Convert.ToInt32(dict["speed"]) / 10, Convert.ToInt32(dict["distance"]) / 10.0, Convert.ToInt32(lblPower.Text), Convert.ToInt32(dict["requested_power"]), lblTime.Text, Convert.ToInt32(dict["rpm"]), Convert.ToInt32(dict["pulse"]), lblEnergy.Text);

                }
            }));
            thread.Start();
            timer1.Start();
        }

        private void BtnDistance_Click(object sender, EventArgs e) => bicycle.RequestDistance(Convert.ToInt32(Convert.ToDouble(txtDistance.Text) * 10));

        private void BtnTime_Click(object sender, EventArgs e) => bicycle.RequestTime(txtTime.Text.Replace(":", ""));

        private void BtnRequestedPower_Click(object sender, EventArgs e) => bicycle.RequestPower(Convert.ToInt32(txtRequestedPower.Text), emergencyStop);

        private void BtnSend_Click(object sender, EventArgs e)
        {
            var msg = new
            {
                id = txtCommand.Text,
                data = new { }
            };
            this.client.Send(this.jsonConnector.SendTunnel(dest, msg));
        }

        public static void ChangeTime(string time)
        {
            bicycle.RequestTime(time);
        }

        public static void ChangePower(int power)
        {
            bicycle.RequestPower(power, false);
        }

        private void BtnSendAndReceive_Click(object sender, EventArgs e)
        {
            var msg = new
            {
                id = txtCommand.Text,
                data = new { }
            };

            txbJSON.Text = this.client.SendAndReceive(this.jsonConnector.SendTunnel(dest, msg));
        }

        private void TrackBar1_Scroll(object sender, EventArgs e) => this.client.SendAndReceive(
            this.jsonConnector.SendTunnel(dest, jsonConnector.SkyboxSetTime(trackBar1.Value)));

        private bool IsValuePresent(dynamic values, String command)
        {
            try
            {
                if (values != null && values.data != null && values.data.data != null
                    && values.data.data.data != null && values.data.data.data[0] != null && values.data.data.data[0].uuid != null)
                {
                    if (values.data.data.id == command)
                        return true;
                    return false;
                }
            }
            catch (Exception) { }
            return false;
        }
    }
}