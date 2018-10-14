using System;
using System.Collections.Generic;
using System.Text;
using Utils.Model;

namespace Utils.Credentials
{
	class LoginStorage
	{
		public Dictionary<string, string> Storage { get; }


		public LoginStorage()
		{
			this.Storage = new Dictionary<string, string>();
			this.Storage.Add("Dokter", "Welkom123");
        }

		
	}
}
