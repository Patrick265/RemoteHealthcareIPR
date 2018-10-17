using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using Utils.Connection.Client;
using System.Web;
using Utils.Model;

namespace DoctorClient
{
	public partial class Form1 : Form
	{
        JsonConnector jc = new JsonConnector();
        public  List<string> machineNames = new List<string>();
        public static List<Patient> patients = new List<Patient>();
        public static List<string> names = new List<string>();
        public static List<Patient> patientNames;
        public ClientDoctor doctor { get; }
        private string name;
        private string s;
        public BikeClientInfo bc;
        private Patient patient;

        public Form1(ClientDoctor clientDoctor, Patient patient)
		{

            InitializeComponent();
            this.Text = "Main Menu";
            this.tabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            this.tabControl1.DrawItem += new DrawItemEventHandler(this.tabControl1_DrawItem);
            this.doctor = clientDoctor;
            if (Form1.patients == null)
                patients = new List<Patient>();
            listBox1.DataSource = machineNames;
            listBox2.DataSource = names;

            this.patient = patient;
            Console.WriteLine("PATIENT IN FORM: " + patient.ToString());
            GenderCombo.SelectedIndex = 0;
        }

        public static void getNames()
        {
            names.Clear();
            foreach(Patient p in patients)
            {
                names.Add(p.name + "---" + p.date);
            }
        }
        
        public void UpdateForm(List<string> machines, List<Patient> info)
        {
            machineNames = machines;
            patients = info;
            listBox1.DataSource = null;
            listBox2.DataSource = null;
            this.Invoke((MethodInvoker)delegate ()
            {
                //listBox1.Hide();
                listBox1.DataSource = machineNames;
                Console.WriteLine("machinenames: " + machineNames.Count);
                //listBox1.Show();
                //listBox2.Hide();
                listBox2.DataSource = names;
                //Console.WriteLine("patient namen: " + patients.Count);
                //listBox2.Show();
            });
        }

        //private void Update()
        //{
        //    while (true)
        //    {
        //        Thread.Sleep(100);
        //        listBox1.DataSource = null;
        //        listBox2.DataSource = null;
        //        this.Invoke((MethodInvoker)delegate ()
        //        {
        //            listBox1.Hide();
        //            listBox1.DataSource = machineNames;
        //            listBox1.Show();
        //            listBox2.Hide();
        //            listBox2.DataSource = names;
        //            listBox2.Show();
        //        });
        //        //Console.WriteLine("machines: " + machineNames.Count);
        //    }
        //}

        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Graphics g = e.Graphics;
            TabPage tp = tabControl1.TabPages[e.Index];
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            RectangleF headerRect = new RectangleF(e.Bounds.X, e.Bounds.Y + 2, e.Bounds.Width, e.Bounds.Height - 2);
            SolidBrush sb = new SolidBrush(Color.White);
            if (tabControl1.SelectedIndex == e.Index)
                sb.Color = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            g.FillRectangle(sb, e.Bounds);
            g.DrawString(tp.Text, tabControl1.Font, new SolidBrush(Color.Black), headerRect, sf);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string machineNameV = listBox1.SelectedItem.ToString();
                machineNames.Remove(machineNameV);
                name = listBox2.SelectedItem.ToString();
                string nameOnly = name.Split('-')[0];
                string date = name.Split('-')[3];
                Console.WriteLine("PATIENT INDEX IN NAME: " + names.IndexOf(name));
                //Console.WriteLine("PATIENTNAMES AMOUNT: " + patientNames.Count);
                Patient p = patients.ElementAt(names.IndexOf(name));
                names.Remove(name);
                doctor.SendCombo(machineNameV, nameOnly, date);
                
                bc = new BikeClientInfo(machineNameV, tabControl1, doctor, nameOnly, date, p);
                doctor.GetOldData(nameOnly);
                bc.Dock = DockStyle.Fill;
                TabPage tp = new TabPage();

                tp.Text = nameOnly + tabControl1.TabCount;

                tp.Controls.Add(bc);
                tabControl1.TabPages.Add(tp);
                tabControl1.SelectedTab = tp;
                UpdateForm(machineNames, patientNames);
                this.doctor.StartSession(60);
                this.tabControl1.SelectedTab = tp;
                bc.LoadItems();
            }
            catch
            {
                MessageBox.Show("Please select a machinename and a patient!", "Warning" );
            }
        }

        

       
        public Patient SearchPatient(string name)
        {
            foreach (Patient p in patientNames)
            {
                if (p.name == name)
                    return p;
            }
            return null;
        }

        public Patient GetPatient(string name)
        {
            Patient pa = new Patient();
            foreach(Patient p in patients)
            {
                if(name == p.name)
                {
                    pa = p;
                }
            }
            return pa;
        }

        private void txtReqDistance_TextChanged(object sender, EventArgs e)
        {
            CheckPatienValuesPresent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            CheckPatienValuesPresent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            CheckPatienValuesPresent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            CheckPatienValuesPresent();
        }

        private void CheckPatienValuesPresent()
        {
            button1.Enabled = false;
            if (txtReqDistance.TextLength != 0 && textBox1.TextLength != 0 && textBox2.TextLength != 0 && dateTimePicker1.Value < DateTime.Today)
                button1.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool result1 = float.TryParse(textBox1.Text, out float weight);
            bool result2 = int.TryParse(textBox1.Text, out int height);
            if (result1 && result2)
            {
                Patient pc = doctor.AddPatient(txtReqDistance.Text, weight, height, dateTimePicker1.Value.Day + "/" + dateTimePicker1.Value.Month + '/' + dateTimePicker1.Value.Year, GenderCombo.SelectedItem.ToString() == "Man");
                txtReqDistance.Text = "";
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.Value = DateTime.Today;


                patients.Add(pc);
                getNames();
                UpdateForm(machineNames, patients);
                MessageBox.Show("Patient added");
            }
            else MessageBox.Show("Enter valid values for 'gewicht' and 'hoogte'");
        }

		private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
		{
		}

		private void ChangeButton_Click(object sender, EventArgs e)
		{
			Console.WriteLine("SELECTED INDEX: " + listBox2.SelectedIndex);
			if (listBox2.SelectedIndex != -1)
			{
				Form changePatient = new ChangePatient(patients, listBox2.SelectedIndex, this);
				changePatient.Show();
			}
			else
			{
				MessageBox.Show("Selecteer alstublieft een patient eerst!");
			}
		}
	}
}
