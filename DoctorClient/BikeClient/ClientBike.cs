using Newtonsoft.Json;
using System;
using System.Net.Sockets;
using System.Threading;
using Utils.Connection;

namespace BikeClient
{
    /// <summary>
    /// This class represents the sending and receiving methods and threads of a bike.
    /// </summary>
    public class ClientBike
    {
        private NetworkStream stream;
        JsonConnector jc = new JsonConnector();

        /// <summary>
        /// This method is called when the ClientBike is ready to connect with the server.
        /// The IP address of the server needs to be filled in, the port is alway the same.
        /// </summary>
        public void ServerConnect()
        {
            TcpClient client = new System.Net.Sockets.TcpClient(
                GlobalData.ClientBikeIP,
                GlobalData.Port);

            stream = client.GetStream();

            Thread thread = new Thread(new ThreadStart(MethodThread));
            thread.Start();
            Console.WriteLine("Send json");
        }

        /// <summary>
        /// This method is running the thread started by the ServerConnect() method
        /// It listens to incoming messages and enters the switch case which switches on the id from the message
        /// </summary>
        public void MethodThread()
        {
            Console.WriteLine("started listening");
            while (true)
            {
                try
                {
                    dynamic jsonRecieve = JsonConvert.DeserializeObject(ConnectionUtils.ReadMessage(stream));
                    string id = jsonRecieve.id;
                    switch (id)
                    {
                        case "Ack":
                            Console.WriteLine("Bike added");
                            break;
                        case "Change":
                            int distance = jsonRecieve.data.distance;
                            int requestedPower = jsonRecieve.data.requestedPower;
                            string time = jsonRecieve.data.time;
                            SimulatorGUI.ChangeBikeValues(distance, requestedPower, time);
                            break;
                        case "ChangeTime":
                            Console.WriteLine("Changed time");
                            string timeChange = jsonRecieve.time;
                            SimulatorGUI.ChangeTime(timeChange);
                            break;
                        case "ChangePower":
                            int rqPower = jsonRecieve.requestedPower;
                            SimulatorGUI.ChangePower(rqPower);
                            break;
                        case "Message":
                            Console.WriteLine("JSON: " + jsonRecieve);
                            string message = jsonRecieve.message;
                            int value = jsonRecieve.value;
                            Console.WriteLine("Recieved message: " + message);
                            if (value == 1)
                            {
                                SimulatorGUI.tempMessage = message;
                            }
                            else
                            {
                                SimulatorGUI.warningMessage = message;
                            }
                            break;
                        case "PersonalMessage":
                            string messageP = jsonRecieve.message;
                            Console.WriteLine("Personal message: " + messageP);
                            SimulatorGUI.tempMessage = messageP;
                            break;
                        case "EmergencyStop":
                            Console.WriteLine("Emergency stop!");
                            SimulatorGUI.ChangeBikeValues(25);
                            SimulatorGUI.emergencyStop = true;
                            break;
                        case "Time":
                            string timeT = jsonRecieve.time;
                            SimulatorGUI.time = timeT;
                            break;
                    }
                }
                catch(Exception e)
                {

                }
            }
        }

        /// <summary>
        /// Sends the info of the bike to the server
        /// </summary>
        /// <param name="speed">speed of the bike</param>
        /// <param name="distance">distance of the bike</param>
        /// <param name="power">power of the bike</param>
        /// <param name="rqPower">The requested power of the bike(the power which the bike is building towards)</param>
        /// <param name="time">The time of the bike</param>
        /// <param name="RPM">The rounds per minute of the bike</param>
        /// <param name="pulse">The pulse (HeartBeat) of the bike</param>
        /// <param name="energy">The energy of the bike user</param>
        public void SendBikeInfo(int speed, double distance, int power, int rqPower, string time, int RPM, int pulse, string energy)
        {
            //Console.WriteLine("info send");
            dynamic json = jc.getJson(jc.SendBikeInfo(speed, distance, power, rqPower, time, RPM, pulse, energy));
            ConnectionUtils.SendMessage(this.stream, json);
        }

        /// <summary>
        /// This method is called when the ClientBike is ready to get added into the servers program. 
        /// (Nedds to be called before you want to start sending updates)
        /// </summary>
        public void SendAdd()
        {
            dynamic json = jc.getJson(jc.Connect(false));
            ConnectionUtils.SendMessage(this.stream, json);
        }
    }
}