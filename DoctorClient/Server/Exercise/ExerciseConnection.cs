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

        public void SendInfoBike(string info, int value)
        {
            string json = jc.getJson(jc.SendMessage(info, value));
            ConnectionUtils.SendMessage(this.BikeStream, json);
        }

        public void SendInfoDoctor(string info, string machineName, int value)
        {
            string json = jc.getJson(jc.SendDocAstrandInfo(info, machineName, value));
            ConnectionUtils.SendMessage(this.DoctorStream, json);
        }

        public void SendTimeDoctor(string time, string name)
        {
            dynamic json = jc.getJson(jc.SendTime(time, name));
            ConnectionUtils.SendMessage(this.DoctorStream, json);
        }

        public void SendTimeBike(string time, string name)
        {
            dynamic json = jc.getJson(jc.SendTime(time, name));
            ConnectionUtils.SendMessage(this.BikeStream, json);
        }

        public void WriteSessionToFile(AstrandSession session)
        {
            if(new FileInfo("../../res/AstrandSession.json").Length != 0)
            {
                string json = File.ReadAllText("../../res/AstrandSession.json");
                dynamic list = JsonConvert.DeserializeObject(json);
                List<AstrandSession> oldSessions = list.ToObject<List<AstrandSession>>();
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

        public string secondsTommss(int seconds)
        {
            return ((seconds - seconds % 60) / 60).ToString("00") + ":" + (seconds % 60).ToString("00");
        }
    }
}
