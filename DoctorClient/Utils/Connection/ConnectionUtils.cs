using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Utils.Connection
{
	class ConnectionUtils
	{
		public static Encoding encoding = Encoding.UTF8;

		public static string ReadMessage(NetworkStream networkStream)
		{
            lock (networkStream)
            {
                byte[] buffer = new byte[4];
                int totalRead = 0;
                //read bytes until stream indicates there are no more
                do
                {
                    if (!networkStream.DataAvailable)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    int read = networkStream.Read(buffer, totalRead, buffer.Length - totalRead);
                    totalRead += read;
                } while (totalRead != 4);

                UInt32 lenght = BitConverter.ToUInt32(buffer, 0);
                buffer = new byte[lenght];
                totalRead = 0;

                do
                {
                    if (!networkStream.DataAvailable)
                    {
                        Thread.Sleep(10);
                        continue;
                    }
                    int read = networkStream.Read(buffer, totalRead, buffer.Length - totalRead);
                    totalRead += read;
                } while (lenght != encoding.GetString(buffer, 0, totalRead).Length);

                return encoding.GetString(buffer, 0, totalRead);
            }
		}

		public static void SendMessage(NetworkStream networkStream, string message)
		{
			//make sure the other end decodes with the same format!
			byte[] bytes = encoding.GetBytes(message);

			byte[] lengthPrefix = BitConverter.GetBytes(message.Length);

			// Concatenate the length prefix and the message
			byte[] ret = new byte[lengthPrefix.Length + message.Length];
			lengthPrefix.CopyTo(ret, 0);
			bytes.CopyTo(ret, lengthPrefix.Length);

			try
			{
				networkStream.Write(lengthPrefix, 0, 4);
				networkStream.Write(bytes, 0, bytes.Length);
			} catch (IOException)
			{
				Console.WriteLine("Not able to write");
			}
		}
	}
}
