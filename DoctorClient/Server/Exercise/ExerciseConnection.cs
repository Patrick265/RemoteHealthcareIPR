using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using Utils.Connection;
using Utils.Model;

namespace Server.Exercise
{
    public class ExerciseConnection
    {
        #region Fields
        private readonly JsonConnector jc;
        #endregion

        #region Property
        public NetworkStream BikeStream { get; set; }
        public NetworkStream DoctorStream { get; set; }
        #endregion

        public ExerciseConnection(NetworkStream bikeStream, NetworkStream doctorStream)
        {
            this.jc = new JsonConnector();
            this.BikeStream = bikeStream;
            this.DoctorStream = doctorStream;
        }

        public void SendChangeTime(string time, string machineName)
        {
            dynamic message = this.jc.getJson(jc.SendChangeTime(time, machineName));
            ConnectionUtils.SendMessage(this.BikeStream, message);
        }

        public void sendChangePower(int power, string machineName)
        {
            dynamic message = this.jc.getJson(jc.SendChangePower(machineName, power));
            ConnectionUtils.SendMessage(this.BikeStream, message);
        }

        public void SendInfoBike(string info)
        {
            string json = jc.getJson(jc.SendMessage(info));
            ConnectionUtils.SendMessage(this.BikeStream, json);
        }

        public void SendInfoDoctor(string info, string machineName)
        {
            string json = jc.getJson(jc.SendDocAstrandInfo(info, machineName));
            ConnectionUtils.SendMessage(this.DoctorStream, json);
        }


        public void WriteSessionToFile(AstrandSession session)
        {
            if(new FileInfo("../../res/AstrandSession.json").Length != 0)
            {
                string json = File.ReadAllText("../../res/AstrandSession.json");
                Console.WriteLine("ASTRAND OPSLAG" + "json");
                dynamic list = JsonConvert.DeserializeObject(json);
                Console.WriteLine("de dynamic: " + list);

                List<AstrandSession> oldSessions = list.ToObject<List<AstrandSession>>();
                //oList(List<AstrandSession>);
                //JsonConvert.DeserializeObject<List<AstrandSession>>(json);
                oldSessions.Add(session);
                File.WriteAllText("../../res/AstrandSession.json", JsonConvert.SerializeObject(oldSessions.ToArray()));
            }
            else
            {
                List<AstrandSession> sessions = new List<AstrandSession>();
                sessions.Add(session);
                File.WriteAllText("../../res/AstrandSession.json", JsonConvert.SerializeObject(sessions.ToArray()));
                Console.WriteLine();
            }

        }
    }
}
