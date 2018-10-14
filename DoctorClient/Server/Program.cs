using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Connection;

namespace Server
{
	class Program
	{
		static void Main(string[] args)
		{
            Server server = new Server(GlobalData.Port);
            server.Launch();
		}
	}
}
