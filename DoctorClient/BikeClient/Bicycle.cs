using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BikeClient
{
    class Bicycle : IBicycle
    {
        private bool commandRights = false;
        private String receivedData;
        private SerialPort comPort;
        static AutoResetEvent autoEvent;

        public Bicycle(String portName)
        {
            autoEvent = new AutoResetEvent(false);
            comPort = new SerialPort(portName);
            comPort.RtsEnable = true;
            comPort.DtrEnable = true;
            comPort.BaudRate = 9600;
            comPort.Parity = Parity.None;
            comPort.StopBits = StopBits.One;
            comPort.DataBits = 8;
            comPort.Handshake = Handshake.None;
            comPort.ReadTimeout = 2000;
            comPort.WriteTimeout = 500;

            comPort.Open();
            comPort.DataReceived += new SerialDataReceivedEventHandler(Port_DataReceived);
        }

        public bool RequestCommandMode()
        {
            comPort.Write("CM" + Environment.NewLine);
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                commandRights = true;
                return true;
            }

            return false;
        }

        public bool RequestDistance(int distance)
        {
            if (!commandRights) return false;

            comPort.Write($"PD{distance}{Environment.NewLine}");
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return true;
            }

            return false;
        }

        public string RequestFirmwareVersion()
        {
            comPort.Write("VE" + Environment.NewLine);
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return receivedData.Remove(receivedData.Length - 2);
            }

            return "-"; 
        }

        public string RequestID()
        {
            comPort.Write("ID" + Environment.NewLine);
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return receivedData.Remove(receivedData.Length - 2);
            }

            return "";
        }

        public bool RequestPower(int power, bool emergencyStop)
        {
            if (!commandRights) return false;
            if (emergencyStop) power = 25;

            comPort.Write($"PW{ power}{ Environment.NewLine}");
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return true;
            }

            return false;
        }

        public bool RequestTime(String time)
        {
            if (!commandRights) return false;

            comPort.Write($"pt{ time}{ Environment.NewLine}");
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return true;
            }

            return false;
        }

        public Dictionary<String, String> RequestStatus()
        {
            Dictionary<String, String> data = new Dictionary<String, String>();

            comPort.Write("ST" + Environment.NewLine);
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                String[] receivedDataSplit = receivedData.Split('\t');
                
                for(int i = 0; i < receivedDataSplit.Length; i++)
                {
                    switch (i)
                    {
                        case 0:
                            data.Add("pulse", receivedDataSplit[i]);
                            break;
                        case 1:
                            data.Add("rpm", receivedDataSplit[i]);
                            break;
                        case 2:
                            data.Add("speed", receivedDataSplit[i]);
                            break;
                        case 3:
                            data.Add("distance", receivedDataSplit[i]);
                            break;
                        case 4:
                            data.Add("requested_power", receivedDataSplit[i]);
                            break;
                        case 5:
                            data.Add("energy", receivedDataSplit[i]);
                            break;
                        case 6:
                            data.Add("mmss", receivedDataSplit[i]);
                            break;
                        case 7:
                            data.Add("actual_power", receivedDataSplit[i]);
                            break;
                    }
                }
            }

            return data;
        }

        public bool ResetDevice()
        {
            comPort.Write("RS" + Environment.NewLine);
            autoEvent.WaitOne();
            if (receivedData != "ERROR\r\n")
            {
                return true;
            }

            return false;
        }

        public void Port_DataReceived(object sender, EventArgs e)
        {
            receivedData = comPort.ReadLine();
            if (!(receivedData == ""))
            {
                Debug.WriteLine(receivedData);
            }

            autoEvent.Set();
        }

        public void Disconnect()
        {
            comPort.Close();
        }
    }
}