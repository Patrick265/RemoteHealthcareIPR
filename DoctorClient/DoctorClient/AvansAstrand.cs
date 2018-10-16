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
        public TextBox infoScreen;
        public Label UpdateText;
        public Chart Chart;
        private ClientDoctor doctor;
        public string time;
        private Exercise exercise;
        private bool hasBeen0;
        

        public AvansAstrand(ClientDoctor doctor, string name, Patient p, BikeClientInfo bikeInfo)
        {
            InitializeComponent();
            this.time = "";
            this.doctor = doctor;
            this.Chart = DataChart;
            this.infoScreen = InfoBox;
            this.UpdateText = UpdateLabel;
            Patient patient = p;
            this.exercise = new Exercise(this, doctor, name, patient, bikeInfo);
            this.hasBeen0 = false;
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
            if(time == "07:00" || time == "03:50" || time == "00:01")
            {
                exercise.Index++;
                exercise.Next();
            }
        }
    }
}
