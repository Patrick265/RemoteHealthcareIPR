using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net.Sockets;

namespace Utils.Connection.Client
{

	class Client
	{
		public TcpClient TcpClient;
		public NetworkStream NetworkStream;
		public String IP;
		public int Port;
		private StreamReader reader;

		public Client(string ip, int port)
		{
			IP = ip;
			Port = port;
			Connect();
		}

		public void Connect()
		{
			this.TcpClient = new TcpClient(this.IP, this.Port);
			TcpClient.SendBufferSize = 655360;
			TcpClient.ReceiveBufferSize = 655360;
			this.NetworkStream = TcpClient.GetStream();
			this.reader = new StreamReader(this.NetworkStream);
		}

		public void Disconnect()
		{
			this.TcpClient.Close();
			this.NetworkStream.Close();
		}

		public string SendAndReceive(String message)
		{
			String command = "";
			ConnectionUtils.SendMessage(NetworkStream, message);

			dynamic json = JsonConvert.DeserializeObject(message);
			command = json.id;

			string response = ConnectionUtils.ReadMessage(NetworkStream);
			return response;
		}

		public void Send(String message)
		{
			ConnectionUtils.SendMessage(NetworkStream, message);
		}

        public String Read()
        {
            string response = ConnectionUtils.ReadMessage(NetworkStream);
            return response;
        }
	}
}
