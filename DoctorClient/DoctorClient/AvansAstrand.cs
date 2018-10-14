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

namespace DoctorClient
{
    public partial class AvansAstrand : Form
    {
        public TextBox infoScreen;
        public Label UpdateText;
        private ClientDoctor doctor;
        public string time;
        private Exercise exercise;
        private Timer timer;

        public AvansAstrand(ClientDoctor doctor, string name)
        {
            InitializeComponent();
            this.time = "";
            this.doctor = doctor;
            this.infoScreen = InfoBox;
            this.UpdateText = UpdateLabel;
            this.exercise = new Exercise(this, doctor, name);
            this.timer = new Timer(1000);
            this.timer.Elapsed += CheckTime;
            this.timer.AutoReset = true;
            this.timer.Enabled = true;
        }

        public void CheckTime(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("TIME: " + time);
            if(time == "00:00" || time == "00:10" || time == "00:20" || time == "01:20")
            {
                exercise.Index++;
                exercise.Next();
            }
        }
    }
}
