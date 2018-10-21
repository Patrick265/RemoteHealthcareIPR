using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Utils.Model;

namespace DoctorClient
{
    public partial class Form2 : Form
    {
        private ClientDoctor Doctor;
        private List<string> DateList = new List<string>();
        private List<AstrandSession> session;
        private Patient Patient;

        public Form2(ClientDoctor clientDoctor, Patient patient)
        {
            InitializeComponent();
        }
    }
}
