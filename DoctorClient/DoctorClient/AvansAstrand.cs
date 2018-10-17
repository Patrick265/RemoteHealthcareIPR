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
        private Exercise exercise;
        private bool hasBeen0;


        public AvansAstrand(ClientDoctor clientDoc, string name, Patient p, BikeClientInfo bikeInfo)
        {
            InitializeComponent();
            this.time = "";
            this.doctor = clientDoc;
            this.Chart = DataChart;
            this.infoScreen = InfoBox;
            this.UpdateText = UpdateLabel;
            this.HeartBeatLabel = HartslagLabel;
            this.RPMLabel = RPMlabel;
            this.PowerLabel = WeerstandLabel;
            Patient patient = p;
            this.exercise = new Exercise(this, doctor, name, patient, bikeInfo);
            this.hasBeen0 = false;
            this.doctor.AvansAstrand = this;
        }

        public void CheckTime()
        {
            if (!hasBeen0)
            {
                if (time == "10:00")
                {
                    exercise.Index++;
                    exercise.Next();
                    hasBeen0 = true;
                }
            }
            if (time == "07:00" || time == "03:50" || time == "00:01")
            {
                exercise.Index++;
                exercise.Next();
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

                    double rpm= Convert.ToDouble(this.doctor.bikeInfoData.data.RPM.ToString()) / 10;
                    this.Chart.Series["RPM"].Points.Add(rpm);
                    this.RPMLabel.Text = "RPM: " + rpm;

                    this.Chart.Series["Weerstand"].Points.Add(Convert.ToDouble(this.doctor.bikeInfoData.data.power.ToString()));
                    this.PowerLabel.Text = "Weerstand:  " + this.doctor.bikeInfoData.data.power.ToString() + "  W";
                     
                }));
            }
        }
    }
}
