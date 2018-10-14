using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    class Doctor
    {
        public String username { get; set; }
        public String password { get; set; }

        public Doctor(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
    }
}
