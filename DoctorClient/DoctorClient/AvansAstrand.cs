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
        private bool hasBeen0;

        public AvansAstrand(ClientDoctor doctor, string name)
        {
            InitializeComponent();
            this.time = "";
            this.doctor = doctor;
            this.infoScreen = InfoBox;
            this.UpdateText = UpdateLabel;
            this.exercise = new Exercise(this, doctor, name);
            this.hasBeen0 = false;
        }

        public void CheckTime()
        {
            Console.WriteLine("TIME: " + time);
            if (!hasBeen0)
            {
                if (time == "00:00")
                {
                    exercise.Index++;
                    exercise.Next();
                    hasBeen0 = true;
                }
            }
            if(time == "00:10" || time == "00:20" || time == "01:20")
            {
                exercise.Index++;
                exercise.Next();
            }
        }
    }
}
