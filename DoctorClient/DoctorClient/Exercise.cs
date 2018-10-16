using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
using Utils.Model;

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
        private Patient patient;
        private int TargetWatt;
        private BikeClientInfo bikeInfo;
        private List<int> PulseValues;


        public Exercise(AvansAstrand form, ClientDoctor doctor, string name, Patient p, BikeClientInfo bikeInfo)
        {
            this.bikeInfo = bikeInfo;
            this.patient = p;
            this.machineName = name;
            this.doctor = doctor;
            this.form = form;
            this.Index = 0;
            PulseValues = new List<int>();
            GetStartingWatt();
            Next();
        }

        public void Next()
        {
            switch (this.Index)
            {
                case 0:
                    StartUpTest();
                    break;
                case 1:
                    StartWarmUp();
                    break;
                case 2:
                    StartTrainingSession();
                    break;
                case 3:
                    CheckSteadyState();
                    break;
                case 4:
                    StartCooldown();
                    break;
                case 5:
                    StopExercise();
                    break;
            }
        }

        /// <summary>
        /// Method gets executed when the test starts
        /// </summary>
        public void StartUpTest()
        {
            form.UpdateText.Text = "Over 5 seconden begint de warming-up";
            doctor.BroadcastPersonalMessage("Over 5 seconden begint de warming-up", machineName);
            doctor.SendChangeTime("0705", machineName);
        }

        /// <summary>
        /// Method gets executed when the warmup needs to start and sets the power to 50
        /// </summary>
        public void StartWarmUp()
        {
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "Fiets 2 minuten lang op een rustig tempo";
            }));
            
            doctor.BroadcastPersonalMessage("Fiets 2 minuten lang op een rustig tempo", machineName);
            doctor.SendChangePower(50, machineName);
            power = 50;
        }

        /// <summary>
        /// Method gets executed when the first 2 minutes of the real test start and starts the build up to the targetWatt
        /// </summary>
        public void StartTrainingSession()
        {
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "De trainingsessie is begonnen, fiets met een RPM van 60!";
            }));

            doctor.BroadcastPersonalMessage("De trainingsessie is begonnen, fiets met een RPM van 60!", machineName);

            BuildToTargetTimer();
        }

        /// <summary>
        /// Method gets executed in the last 2 minutes of the real test and monitors the pulse every 15 seconds. After this it checks 
        /// if the steady state was reached
        /// </summary>
        public void CheckSteadyState()
        {
            timer = new Timer(15000);
            timer.Elapsed += GetPulse;
            timer.Start();
            while(PulseValues.Count < 8)
            {

            }

            int min = PulseValues.Min();
            int max = PulseValues.Max();
            if ((max-min) <= 5)
            {
                GetAverage();
                //If average is below 130 execute the checksteadystate again with a higher watt(update timer)
            }
            else
            {
                //Check if there are invalid values in the pulseValues and filter them out
                //if after this check there's still no steady state you need to execute another 2 minutes of checksteadystate (update timer)
            }
                
        }

        /// <summary>
        /// Method is executed when the cooldown can start
        /// </summary>
        public void StartCooldown()
        {
            form.Invoke(new MethodInvoker(delegate
            {
                form.UpdateText.Text = "De cooldown is begonnen, fiets op een rustig tempo door";
            }));

            doctor.BroadcastPersonalMessage("De cooldown is begonnen, fiets op een rustig tempo door", machineName);
            
            timer = new Timer(5000);
            timer.Elapsed += DecreasePower;
            timer.Start();
        }

        /// <summary>
        /// Method is executed when the cooldown is finished
        /// </summary>
        public void StopExercise()
        {
            form.UpdateText.Text = "De Avans Astrand test is afgelopen";
            doctor.BroadcastPersonalMessage("De Avans Astrand test is afgelopen", machineName);
        }




        /// <summary>
        /// Method starts the timer for building to the targetWatt
        /// </summary>
        public void BuildToTargetTimer()
        {
            timer = new Timer(5000);
            timer.Elapsed += BuildToTarget;
            timer.Start();
        }

        /// <summary>
        /// Method gets the pulse from the bike and adds it to the list with values
        /// </summary>
        public void GetPulse(Object source, ElapsedEventArgs e)
        {
            PulseValues.Add(bikeInfo.pulse);
        }

        /// <summary>
        /// Method is executed by the BuildToTargetTimer and increments the power by 5 until the TargetWatt is reached.
        /// When reached the method stops the timer and checks if the pulse of the patient is high enough. If not the timer is
        /// called again with additional 25 watt
        /// </summary>
        public void BuildToTarget(Object source, ElapsedEventArgs e)
        {
            if(power < TargetWatt)
            {
                power = power + 5;
                doctor.SendChangePower(power, machineName);
            }
            else
            {
                timer.Stop();
                if(bikeInfo.pulse < 110)
                {
                    TargetWatt += 25;
                    BuildToTargetTimer();
                }
            }
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

        /// <summary>
        /// When tis method is executed it checks the patient info and determines the appropriate TargetWatt
        /// </summary>
        public void GetStartingWatt()
        {
            if (patient.male)
            {
                TargetWatt = 125;
            }
            else
            {
                TargetWatt = 110;
            }
        }
        
        public void GetAverage()
        {

        }

    }
}
