using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace DoctorClient
{
    class Exercise
    {
        private AvansAstrand form;
        private ClientDoctor doctor;
        private string machineName;
        public int Index { get; set; }
        private int power;
        private Timer timer;
        private bool boolStartUpTest;
        private bool boolStartWarmUp;
        private bool boolStartTrainingsession;


        public Exercise(AvansAstrand form, ClientDoctor doctor, string name)
        {
            this.machineName = name;
            this.doctor = doctor;
            this.form = form;
            this.Index = 0;
            this.boolStartUpTest = false;
            this.boolStartWarmUp = false;
            this.boolStartTrainingsession = false;
            Next();
        }

        public void Next()
        {
            switch (this.Index)
            {
                case 0:
                    if(boolStartUpTest == false)
                    StartUpTest();
                    break;
                case 1:
                    if(boolStartWarmUp == false)
                    StartWarmUp();
                    break;
                case 2:
                    if(boolStartTrainingsession == false)
                    StartTrainingSession();
                    break;
                case 3:
                    StartCooldown();
                    break;
            }
        }

        public void StartUpTest()
        {
            this.boolStartUpTest = true;
            form.UpdateText.Text = "Over 5 seconden begint de warming-up";
            doctor.BroadcastPersonalMessage("Over 5 seconden begint de warming-up", machineName);
            doctor.SendChangeTime("0005", machineName);
        }

        public void StartWarmUp()
        {
            this.boolStartWarmUp = true;
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "Fiets 2 minuten lang op een rustig tempo";
            }));
            
            doctor.BroadcastPersonalMessage("Fiets 2 minuten lang op een rustig tempo", machineName);
            doctor.SendChangePower(50, machineName);
            doctor.SendChangeTime("0000", machineName);
        }

        public void StartTrainingSession()
        {
            this.boolStartTrainingsession = true;
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "De trainingsessie is begonnen, fiets met een snelheid van 20 km/u!";
            }));

            doctor.BroadcastPersonalMessage("De trainingsessie is begonnen, fiets met een snelheid van 20 km/u!", machineName);
            doctor.SendChangePower(200, machineName);
            power = 200;
        }

        public void StartCooldown()
        {
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "De cooldown is begonnen, fiets op een rustig tempo door";
            }));

            doctor.BroadcastPersonalMessage("De cooldown is begonnen, fiets op een rustig tempo door", machineName);
            
            timer = new Timer(5000);
            timer.Elapsed += DecreasePower;
        }

        public void DecreasePower(Object source, ElapsedEventArgs e)
        {
            
            if(power == 25)
            {
                timer.Stop();
            }
            else
            {
                power -= 25;
                doctor.SendChangePower(power, machineName);
            }
        }
        
    }
}
