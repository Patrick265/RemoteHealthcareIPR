using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using Utils.Model;
using System.Threading;
using Newtonsoft.Json;
using System.IO;
using Utils.Credentials;
using Server.Exercise;
using Server.Exercise.State;

namespace Server
{
	class Server
	{
		private IPAddress host;
		private TcpListener listener;
		public Dictionary<string, HandleClient> ClientList { get; set; }
		public List<Patient> PatientList { get; set; }
		public static LoginStorage Storage;
		public ServerUtil Util;
        public static Context exercise { get; set; }

		/// <summary>
		/// The constructor for the server
		/// </summary>
		/// <param name="port">insert the port number here what you want to use</param>
		public Server(int port)
		{
			bool ipIsOk = IPAddress.TryParse(GetLocalIPAddress(), out host);
			if (!ipIsOk)
			{
				Console.WriteLine("IP Adress could not be Parsed");
				Environment.Exit(1);
			}
			this.listener = new TcpListener(host, port);
			this.ClientList = new Dictionary<string, HandleClient>();
			this.PatientList = new List<Patient>();
			this.Util = new ServerUtil();
			this.Util.GenerateJson();
			this.Util.GenTrainingSesJson(this.Util.PatientsInfo);
			Storage = new LoginStorage();
			FillPatientList();
		}

		/// <summary>
		/// This method will run the server
		/// </summary>
		public void Launch()
		{
			listener.Start();
            Console.WriteLine("SERVER STARTED {0}", DateTime.Now);
			while (true)
			{
				TcpClient client = listener.AcceptTcpClient();
				HandleClient clientHandler = new HandleClient(client, this.ClientList, this.PatientList);
				Thread thread = new Thread(new ThreadStart(clientHandler.Run));
				thread.Start();
			}
		}

		private void FillPatientList()
		{
			string values = File.ReadAllText("../../res/PatientData.json");
			List<Patient> json = JsonConvert.DeserializeObject<List<Patient>>(values);
			foreach (Patient patient in json)
			{
				this.PatientList.Add(patient);
			}
		}

		/// <summary>
		/// This method will retrieve your ip adress.
		/// </summary>
		/// <returns>Your ip adress in a string</returns>
		public static string GetLocalIPAddress()
		{
			var host = Dns.GetHostEntry(Dns.GetHostName());
			foreach (var ip in host.AddressList)
			{
				if (ip.AddressFamily == AddressFamily.InterNetwork)
				{
					Console.WriteLine("IP ADRESS: {0} ", ip.ToString());
					return ip.ToString();
				}
			}
			throw new Exception("ERROR: No network adapters with an IPv4 address in the system!");
		}
       
        public static void StartAstrand(string MachineName, Patient Patient, NetworkStream BikeStream, NetworkStream DoctorStream)
        {
            exercise = new Context(new WarmUpState(BikeStream, DoctorStream, Patient, MachineName));
            exercise.Request();
        }
	}
}