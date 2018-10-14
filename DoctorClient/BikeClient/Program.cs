using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Utils.Connection.Client;


namespace BikeClient
{
	static class Program
	{
        public static JsonConnector jsonConnector;
        public static Client client;
        public static String dest;
        public static Thread thread;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Thread.Sleep(1000);
            jsonConnector = new JsonConnector();
            client = new Client("145.48.6.10", 6666);
            string message = "{ \"id\":\"session/list\"}";
            String sessieID = "";
            String status = "";

            
                //get clientinfo for each session active
                dynamic json = JsonConvert.DeserializeObject(client.SendAndReceive(message));
                Newtonsoft.Json.Linq.JArray clientinfos = json.data;
                //search for the session on this computer
                foreach (dynamic client in clientinfos)
                {
                    if (client.clientinfo.user == Environment.UserName && client.clientinfo.host == Environment.MachineName)
                    {
                        sessieID = client.id;
                    }
                }

                
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SimulatorGUI());
        }
    }
}

