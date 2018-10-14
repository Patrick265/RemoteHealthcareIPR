using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoctorClient
{
    public partial class LoginForm : Form
    {
        public Label errorLabel;
        public static ClientDoctor doctor = new ClientDoctor();
        public LoginForm()
        {
            InitializeComponent();
            errorLabel = label_error_message;
            doctor.ServerConnect(this);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String password = box_login_password.Text;
            String username = box_login_username.Text;
            doctor.SendLoginInfo(username,password);
        }
    }
}
