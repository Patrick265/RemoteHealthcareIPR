using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Utils.Model;

namespace DoctorClient
{
    public partial class BikeClientInfo : UserControl
    {
        List<RootObjectSendBikeInfo> allBikeData = new List<RootObjectSendBikeInfo>();
        string bikeName;
        TabControl tabControl1;
        ClientDoctor doctor;
        string patientName;
        string date;
        public Form2 f2;
        public Patient patient { get; set; }
        public string[] chartItems = {"Distance", "Speed", "Requested Power", "Energy", "Power", "Pulse", "RPM"};
        public AvansAstrand aa;

        public BikeClientInfo(string machineName, TabControl tabControl, ClientDoctor clientDoctor, string patientName, string date, Patient patient)
     
        {
            this.bikeName = machineName;
            this.tabControl1 = tabControl;
            this.doctor = clientDoctor;
            InitializeComponent();
            LoginForm.doctor.bikeDataChanged += bikeDataChanged;
            this.patientName = patientName;
            this.date = date;
            lblName.Text = patientName;
            lblDateOfBirth.Text = date;
            lblBikeInfo.Text = bikeName;
            this.patient = patient;
            
        }

        void bikeDataChanged(object _bikeData, EventArgs e)
        {
            try
            {
                RootObjectSendBikeInfo bikeData = (RootObjectSendBikeInfo)_bikeData;
                allBikeData.Add(bikeData);
                this.Invoke(new MethodInvoker(delegate
                {

                    if (bikeData.name == bikeName)
                    {
                        txtDistance.Text = bikeData.data.distance.ToString();
                        txtSpeed.Text = bikeData.data.speed.ToString();
                        txtRequestedPower.Text = bikeData.data.requestedPower.ToString();
                        txtEnergy.Text = bikeData.data.energy.ToString();
                        txtPower.Text = bikeData.data.power.ToString();
                        txtPulse.Text = bikeData.data.pulse.ToString();
                        txtRPM.Text = bikeData.data.RPM.ToString();
                        txtTime.Text = bikeData.data.time;
                        chart1.Series["Energy"].Points.Add(Convert.ToDouble(bikeData.data.energy.Split(' ')[0]));
                        chart1.Series["Power"].Points.Add(Convert.ToDouble(bikeData.data.power));
                        chart1.Series["Distance"].Points.Add(Convert.ToDouble(bikeData.data.distance));
                        chart1.Series["Requested Power"].Points.Add(Convert.ToDouble(bikeData.data.requestedPower));
                        chart1.Series["Pulse"].Points.Add(Convert.ToDouble(bikeData.data.pulse));
                        chart1.Series["RPM"].Points.Add(Convert.ToDouble(bikeData.data.RPM));
                        chart1.Series["Speed"].Points.Add(Convert.ToDouble(bikeData.data.speed));
                    }
                }));
                if (aa != null)
                {
                    if (bikeData.name == bikeName)
                    {
                        aa.Invoke(new MethodInvoker(delegate
                        {
                            if (aa.infoScreen != null)
                            {
                                aa.infoScreen.Text = bikeData.data.time;
                                aa.time = bikeData.data.time;
                                aa.CheckTime();
                            }
                        }));
                    }
                }
            }
            catch
            {
                MessageBox.Show("Dokter has disconnected" );
            }
        }

        public void LoadItems()
        {
            this.Invoke(new MethodInvoker(delegate
            {
                foreach (var item in chartItems)
                {
                    comboBox.Items.Add(item);
                }
            }));
            comboBox.SelectedIndex = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
            doctor.GetOldData(patientName);
            if (patient == null)
            {
                MessageBox.Show("This patient doensn't have older sessions!");
            }
            else
            {
                f2 = new Form2(patientName, date, doctor, patient);
                f2.Show();
            }
        }

 

        private void deletetab_Click (object sender, EventArgs e)
        {
           doctor.machineNames.Add(bikeName);
            Form1.names.Add(patientName + "---" + date);
           doctor.Update();
           tabControl1.TabPages.Remove(tabControl1.SelectedTab);
        }

        private void btnDistancePlus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReqDistance.Text))
            {
                double distancenumber = Double.Parse(txtReqDistance.Text);
                if (distancenumber > 0 && distancenumber < 1000)
                {
                    distancenumber = distancenumber * 10;
                    doctor.SendChangeRequest(txtTime.Text.Split(':')[0] + txtTime.Text.Split(':')[1], distancenumber,
                        bikeName, Int32.Parse(txtRequestedPower.Text));
                }
                else
                {
                    MessageBox.Show("Please enter a value between 0 and 999");
                }
            }
            else
            {
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void btnPowerPlus_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtReqPower.Text))
            {
                int powernumber = Int32.Parse(txtReqPower.Text);
                if (Enumerable.Range(0, 401).Contains(powernumber))
                {
                    doctor.SendChangeRequest(txtTime.Text.Split(':')[0] + txtTime.Text.Split(':')[1],
                        Double.Parse(txtDistance.Text) * 10, bikeName, powernumber);
                }
                else
                {
                    MessageBox.Show("Please enter a value between 25 and 400");
                }

            }
            else
            {
                MessageBox.Show("Please enter a valid value");
            }
        }

        private void txtReqDistance_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtReqDistance.Text, "[^0-9,]"))
            {
                MessageBox.Show("Please enter only numbers and comma's");
                txtReqDistance.Text = txtReqDistance.Text.Remove(txtReqDistance.Text.Length - 1);
            }
        }

        private void txtReqPower_TextChanged(object sender, EventArgs e)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch(txtReqPower.Text, "[^0-9]"))
            {
                MessageBox.Show("Please enter only numbers");
                txtReqPower.Text = txtReqPower.Text.Remove(txtReqPower.Text.Length - 1);
            }
        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMessage.Text))
            {
                doctor.BroadcastPersonalMessage(txtMessage.Text, lblBikeInfo.Text);
            }
            else
            {
                MessageBox.Show("Please write a message first!");
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            doctor.SendEmergencyStop(lblBikeInfo.Text);
            MessageBox.Show("Emergency stop has been send to the patient");
        }

        private void BikeClientInfo_Load(object sender, EventArgs e)
        {

        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleChart();
            chart1.Series[comboBox.Text].Enabled = true;
        }

        private void toggleChart()
        {
            foreach (var item in chartItems)
            {
                chart1.Series[item].Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aa = new AvansAstrand(doctor, bikeName, patient);
            aa.Show();
        }
    }
}
