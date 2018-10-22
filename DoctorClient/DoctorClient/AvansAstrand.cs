using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using Timer = System.Timers.Timer;
using System.Windows.Forms.DataVisualization.Charting;
using Utils.Model;

namespace DoctorClient
{
    public partial class AvansAstrand : Form
    {
        public Label infoScreen;
        public Label UpdateText;
        public Label HeartBeatLabel;
        public Label PowerLabel;
        public Chart Chart;
        private ClientDoctor doctor;
        public string time;
        private bool hasBeen0;
        private string machineName;


        public AvansAstrand(ClientDoctor clientDoc, string name, Patient p, BikeClientInfo bikeInfo)
        {
            InitializeComponent();

            this.machineName = name;
            this.time = "";
            this.doctor = clientDoc;
            this.Chart = DataChart;
            this.infoScreen = InfoBox;
            this.UpdateText = UpdateLabel;
            this.HeartBeatLabel = HartslagLabel;
            this.RPMLabel = RPMlabel;
            this.PowerLabel = WeerstandLabel;
            Patient patient = p;
            //this.exercise = new Exercise(this, doctor, name, patient, bikeInfo);
            this.hasBeen0 = false;
            this.doctor.AvansAstrand = this;
        }
        

        public void SetInfo(string info, string name, int value)
        {
            if(name == machineName)
            {
                if (value == 1)
                {
                    this.Invoke(new MethodInvoker(delegate
                        {
                            UpdateLabel.Text = info;
                        }));
                }
                else
                {

                }
                
            }
        }

        public void SetTime(string time, string name)
        {
            if(name == machineName)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    infoScreen.Text = time;
                }));
            }
        }

        public void FillChart()
        {
            if (this.Chart != null)
            {
                this.Invoke(new MethodInvoker(delegate
                {
                    this.Chart.Series["Hartslag"].Points.Add(Convert.ToDouble(this.doctor.bikeInfoData.data.pulse.ToString()));
                    this.HeartBeatLabel.Text = "Heartbeat: " + this.doctor.bikeInfoData.data.pulse.ToString() + " BPM";

                    double rpm= Convert.ToDouble(this.doctor.bikeInfoData.data.RPM.ToString());
                    this.Chart.Series["RPM"].Points.Add(rpm);
                    this.RPMLabel.Text = "RPM: " + rpm;

                    this.Chart.Series["Weerstand"].Points.Add(Convert.ToDouble(this.doctor.bikeInfoData.data.power.ToString()));
                    this.PowerLabel.Text = "Weerstand:  " + this.doctor.bikeInfoData.data.power.ToString() + "  W";
                     
                }));
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
