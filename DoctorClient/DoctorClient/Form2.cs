using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Utils.Model;

namespace DoctorClient
{
    public partial class Form2 : Form
    {
        ClientDoctor doctor;
        List<string> dateList = new List<string>();
        Patient patient;

        public Form2(  string patientName, string date, ClientDoctor clientDoctor, Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
            setList(patient);
            this.Text = "Client Info";
            this.doctor = clientDoctor;
            nametxt.Text = patientName;
            dateofbirthtxt.Text = date;
            
            listBox1.DataSource = dateList;
            
            
            
        }

        public void setList(Patient patient)
        {
            for (int i = 0; i < patient.TrainingSessions.Count; i++)
            {

                dateList.Add(patient.TrainingSessions[i].date.Split(' ')[0]);
                //Console.WriteLine("TRANINGS SESSION!!!!!!!!!!!!!!!!:");
                //Console.WriteLine(patient.TrainingSessions[i].date);
                //textBox3.Text = (dateList[i]);
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i = listBox1.SelectedIndex;
            textBox3.Text = patient.TrainingSessions[i].ToString();
            
        }
    }
}
