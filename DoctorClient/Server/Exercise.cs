using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Timer = System.Timers.Timer;
using Utils.Model;
using System.Net.Sockets;
using Utils.Connection;

namespace Server
{
    class Exercise
    {
        public int Index { get; set; }
        private int power;
        private Timer timer;
        private Timer timer2;
        private Patient patient;
        private int TargetWatt;
        private List<int> PulseValues;
        private List<int> FirstPulseValues;
        private NetworkStream bikeStream;
        private NetworkStream doctorStream;
        private JsonConnector jc;
        public string machineName;
        private string time;
        public int pulse { get; set; }
        public int rpm { get; set; }
        private bool EndOfCheckFor0;
        private bool CheckRPM;
        public int AvgSteadyStartHeartRate;

        public Exercise(string name, Patient p, NetworkStream bikeStream, NetworkStream doctorStream)
        {
            this.CheckRPM = false;
            this.machineName = name;
            this.jc = new JsonConnector();
            this.bikeStream = bikeStream;
            this.doctorStream = doctorStream;
            this.patient = p;
            this.Index = 0;
            this.EndOfCheckFor0 = false;
            PulseValues = new List<int>();
            FirstPulseValues = new List<int>();
            TargetWatt = p.TargettedWat;
            Console.WriteLine("TARGETWAT: " + TargetWatt);
            StartUpTest();
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
                    //CheckSteadyState();
                    break;
                case 4:
                    //StartCooldown();
                    break;
                case 5:
                    //StopExercise();
                    break;
            }
        }

        public void CheckTime(string time)
        {
            this.time = time;
            if(time == "00:01")
            {
                Console.WriteLine("00:01 bereikt");
                if (!EndOfCheckFor0)
                {
                    Index++;
                    Next();
                }
            }
            if(time == "04:00" || time == "03:00")
            {
                FirstPulseValues.Add(pulse);
            }
            if(time == "02:00")
            {
                CheckSteadyState();
                Console.WriteLine("NEW PULSE: " + pulse);
                PulseValues.Add(pulse);
            }
            if(this.CheckRPM == true)
            {
                if(rpm < 50)
                {
                    SendInfoBike("U fietst niet hard genoeg, probeer rond de 60 rpm te blijven");
                    SendInfoDoctor("De patient fietst te zacht en heeft een waarschuwing gekregen");
                }
                if(rpm > 70)
                {
                    SendInfoBike("U fietst te snel, probeer rond de 60 rpm te blijven");
                    SendInfoDoctor("De patient fietst te hard en heeft een waarschuwing gekregen");
                }
            }
        }

 

        /// <summary>
        /// Method gets executed when the test starts
        /// </summary>
        public void StartUpTest()
        {
            SendChangeTime("0005");
            SendInfoBike("Over 5 seconden begint de warming-up");
            SendInfoDoctor("Over 5 seconden begint de warming-up");
            sendChangePower(50);
            this.power = 50;
        }

        /// <summary>
        /// Method gets executed when the warmup needs to start and sets the power to 50
        /// </summary>
        public void StartWarmUp()
        {
            string info = "Fiets 2 minuten lang op een rustig tempo";
            SendChangeTime("0011");//Test Value
            //SendChangeTime("0200");//Real value
            SendInfoBike(info);
            SendInfoDoctor(info);
        }

        /// <summary>
        /// Method gets executed when the first 2 minutes of the real test start and starts the build up to the targetWatt
        /// </summary>
        public void StartTrainingSession()
        {
            this.EndOfCheckFor0 = true;
            this.CheckRPM = true;
            SendChangeTime("0211");//Test Value
            SendChangeTime("0401");//Real value
            SendInfoBike("De trainingsessie is begonnen, fiets met een RPM van 60!");
            SendInfoDoctor("De trainingsessie is begonnen, fiets met een RPM van 60!");
            GetFirstPulseValuesEx();
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
            
        }

        public void CheckValues()
        {
            int min = PulseValues.Min();
            int max = PulseValues.Max();
            Console.WriteLine("MIN: " + min + " - MAX: " + max);
            if ((max - min) <= 5)
            {
                int average = GetAverage();
                if (average < 90)
                {
                    RestartTest();
                }
                //If average is below 130 execute the checksteadystate again with a higher watt(update timer)
                else
                {
                    StartCooldown();
                }
            }
            else
            {
                RestartTest();
                //Check if there are invalid values in the pulseValues and filter them out
                //if after this check there's still no steady state you need to execute another 2 minutes of checksteadystate (update timer)
            }
        }

        /// <summary>
        /// Method is executed when the cooldown can start
        /// </summary>
        public void StartCooldown()
        {
            this.CheckRPM = false;
            SendChangeTime("0100");
            SendInfoBike("De cooldown is begonnen, fiets op een rustig tempo door");
            SendInfoDoctor("De cooldown is begonnen, fiets op een rustig tempo door");
            sendChangePower(50);
            //timer = new Timer(5000);
            //timer.Elapsed += DecreasePower;
            //timer.Start();
        }

        /// <summary>
        /// Method is executed when the cooldown is finished
        /// </summary>
        public void StopExercise()
        {
            //form.UpdateText.Text = "De Avans Astrand test is afgelopen";
            //doctor.BroadcastPersonalMessage("De Avans Astrand test is afgelopen", machineName);
            //form.infoScreen.Text = "";
        }




        /// <summary>
        /// Method starts the timer for building to the targetWatt
        /// </summary>
        public void BuildToTargetTimer()
        {
            timer2 = new Timer(5000);
            timer2.Elapsed += BuildToTarget;
            timer2.Start();
        }

        /// <summary>
        /// Method gets the pulse from the bike and adds it to the list with values
        /// </summary>
        public void GetPulse(Object source, ElapsedEventArgs e)
        {
            if (PulseValues.Count < 8)
            {
                Console.WriteLine("NEW PULSE: " + pulse + " Amount: " + PulseValues.Count);
                PulseValues.Add(pulse);
            }
            else
            {
                PulseValues.Add(pulse);
                timer.Stop();
                CheckValues();
            }
        }

        /// <summary>
        /// Method is executed by the BuildToTargetTimer and increments the power by 5 until the TargetWatt is reached.
        /// When reached the method stops the timer and checks if the pulse of the patient is high enough. If not the timer is
        /// called again with additional 25 watt
        /// </summary>
        public void BuildToTarget(Object source, ElapsedEventArgs e)
        {
            if (power < TargetWatt)
            {
                power = power + 5;
                sendChangePower(power);
            }
            else
            {
                timer2.Stop();
                if (pulse < 90)
                {
                    TargetWatt += 25;
                    BuildToTargetTimer();
                }
            }
            Console.WriteLine("NEW POWER: " + power);
        }

        public void DecreasePower(Object source, ElapsedEventArgs e)
        {

            if (power == 25)
            {
                timer.Stop();
            }
            else
            {
                power -= 25;
                //doctor.SendChangePower(power, machineName);
            }
            Console.WriteLine("NEW POWER: " + power);
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

        /// <summary>
        /// Method is called when the test needs to restart with additional Watt, needs to update the timer on the bike
        /// </summary>
        public void RestartTest()
        {
            TargetWatt += 25;
            power += 25;
            PulseValues.Clear();
            PulseValues.Add(pulse);
            //BuildToTargetTimer();
            sendChangePower(power);//Would be better to increase the power by steps
            SendChangeTime("0200");
            CheckSteadyState();
            Console.WriteLine("Test needs to be restarted!!");

        }

        public void GetFirstPulseValues(Object source, ElapsedEventArgs e)
        {
            GetFirstPulseValuesEx();
        }

        public void GetFirstPulseValuesEx()
        {
            if (FirstPulseValues.Count < 2)
            {
                //FirstPulseValues.Add(bikeInfo.pulse);
                Console.WriteLine("FIRSTPULSEVALUES: " + FirstPulseValues.Count);

            }
            else
            {
                //FirstPulseValues.Add(bikeInfo.pulse);
                timer.Stop();
                CheckSteadyState();
            }
        }

        public int GetAverage()
        {
            return (int)PulseValues.Average();
        }


        /// <summary>
        /// I assume they mean the targetted watt and the average heartrate of the steadystart
        /// </summary>
        /// <returns></returns>
        public double CalculateVO2Max()
        {
            if(patient.male)
            {
                return (0.00212 * this.patient.TargettedWat + 0.299) / (0.769 * this.AvgSteadyStartHeartRate - 48.5) * 1000;
            }
            else
            {
                return (0.00193 * this.patient.TargettedWat + 0.326) / (0.769 * this.AvgSteadyStartHeartRate - 56.1) * 1000;
            }
        }
    }
}
