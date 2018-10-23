using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Server.Exercise.State

{ public class TrainingState : ExerciseState
    {
        private Context Context;
        private Timer Timer;
        private Timer TimerInfo;
        private Timer PulseTimer;
        private Timer BuildToTargetTimer;
        private int Counter;
        private List<int> PulseSecond;
        private List<int> PulseMinute;
        private bool RetrySteadyState;
        private AstrandSession Session;
        private int Time;

        public TrainingState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
            this.Counter = 0;
            this.RetrySteadyState = true;
            this.Time = 240;
            this.PulseSecond = new List<int>();
            this.PulseMinute = new List<int>();

            this.Timer = new Timer(DurationTrainingSession);
            this.TimerInfo = new Timer(1000);
            this.TimerInfo.Elapsed += GetTime;
            this.TimerInfo.Enabled = true;
            Console.WriteLine("DURATION : " + DurationTrainingSession);
            this.PulseTimer = new Timer(15000);
            this.BuildToTargetTimer = new Timer(3000);
            this.Session = new AstrandSession(base.Patient.name, DateTime.Now);
        }

        public override void Event(Context context)
        {
            this.Context = context;
            this.Timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.Timer.Enabled = true;

            this.PulseTimer.Elapsed += new ElapsedEventHandler(DataRetriever);
            this.PulseTimer.Enabled = true;

            this.BuildToTargetTimer.Elapsed += new ElapsedEventHandler(BuildToTarget);
            this.BuildToTargetTimer.Enabled = true;

            base.Power = 50;
            base.ExerciseConnection.SendChangeTime("0400", base.MachineName);
            base.ExerciseConnection.SendInfoDoctor("De trainingsessie is begonnen, fiets met een RPM van 60!", base.MachineName, 1);
            base.ExerciseConnection.SendInfoBike("De trainingsessie is begonnen, fiets met een RPM van 60!", 1);
            //base.ExerciseConnection.sendChangePower(base.Patient.TargettedWatt, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("CHANGING THE SESSION");
            this.TimerInfo.Stop();
            this.PulseTimer.Stop();
            this.Timer.Stop();
            this.BuildToTargetTimer.Stop();
            //Check if the steady state is reached if yes it goes to the else, otherwise the training state will take 2 min longer.
            if (CheckValues() && RetrySteadyState)
            {
                Console.WriteLine("AVERAGE IS TOO LOW");
                this.PulseMinute = new List<int>();
                this.PulseSecond = new List<int>();
                this.PulseTimer = new Timer(15000);
                this.Timer = new Timer(120000);
                this.Timer.Elapsed += new ElapsedEventHandler(ChangeSession);
                this.Timer.Enabled = true;
                this.PulseTimer.Elapsed += new ElapsedEventHandler(DataRetriever);
                this.PulseTimer.Enabled = true;

                this.RetrySteadyState = false;
                base.ExerciseConnection.SendChangeTime("0400", base.MachineName);
                this.Time = 120;
                this.TimerInfo.Start();
                this.Timer.Start();
                this.PulseTimer.Start();
                base.ExerciseConnection.SendInfoDoctor("De steady state is niet gehaald, de training gaat door met een extra 2 minuten!", base.MachineName, 1);
                base.ExerciseConnection.SendInfoBike("De steady state is niet gehaald, de training gaat door met een extra 2 minuten", 1);
            }
            else if (CheckValues())
            {
                base.ExerciseConnection.WriteSessionToFile(this.Session);
                base.ExerciseConnection.SendInfoDoctor($"Er kan geen Vo2Max berekend worden, het verschil tussen de hartslag was te groot. Max hartslag: {this.PulseSecond.Min()} Min hartslag {this.PulseSecond.Max()}", base.MachineName, 1);
                base.ExerciseConnection.SendInfoBike($"Er kan geen Vo2Max berekend worden, het verschil tussen de hartslag was te groot. Max hartslag: {this.PulseSecond.Min()} Min hartslag {this.PulseSecond.Max()}", 1);
                this.Context.State = new CoolDownState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
                this.Context.Request();
                Console.WriteLine(DateTime.Now + " Changed To Cooldown");
            }
            else
        { 
                ExerciseConnection.SendVo2(CalculateVO2Max(PulseSecond.Average()), MachineName);
                this.Session.VO2 = CalculateVO2Max(PulseSecond.Average());
                base.ExerciseConnection.WriteSessionToFile(this.Session);
                Console.WriteLine("MINUTE: " + this.PulseMinute.Count);
                Console.WriteLine("SECOND: " + this.PulseSecond.Count);
                Console.WriteLine(CalculateVO2Max(PulseSecond.Average()));
                
                this.Context.State = new CoolDownState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
                this.Context.Request();
                Console.WriteLine(DateTime.Now + " Changed To Cooldown");
            }
        }

        public void DataRetriever(object source, ElapsedEventArgs e)
        {
            Console.WriteLine("ENTERED IN THE DATA RETRIEVER");

            if (base.Pulse > base.Patient.MaxHeartRate)
            {
                Console.WriteLine("MAX HEART EXCEEDED");
                this.PulseTimer.Stop();
                this.Timer.Stop();
                this.Context.State = new FinishedState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
                this.Context.Request();
            }

            if (this.Counter == 3 || this.Counter == 7)
            {
                this.Session.data.Add(new AstrandData(base.Rpm, base.Pulse, base.Power));
                Console.WriteLine("SAVING PULSE EVERY MINUTE");
                this.PulseMinute.Add(base.Pulse);
            }
            if (base.Pulse < 110 && this.Counter == 5 && base.Power < base.Patient.TargettedWatt)
            {
                Console.WriteLine("INCREASING POWA");
                base.Power += 25;
                base.ExerciseConnection.sendChangePower(base.Power, base.MachineName);
            }
            if (this.Counter > 7)
            {
                this.Session.data.Add(new AstrandData(base.Rpm, base.Pulse, base.Power));
                Console.WriteLine("SAVING THA PULSE EVERY 15 SECONDAA");
                this.PulseSecond.Add(base.Pulse);
            }
            this.Counter++;
        }

        public bool CheckValues()
        {
            Console.WriteLine("CHECKING THA GODDAMN VALUES");
            int min = this.PulseSecond.Min();
            Console.WriteLine("MIN" + min);

            int max = this.PulseSecond.Max();
            Console.WriteLine("MAX" + max);
            int average = Convert.ToInt32(this.PulseSecond.Average());
            Console.WriteLine("AVERAGE" + average);
            Console.WriteLine("MIN: " + min + " - MAX: " + max);
            if ((max - min) <= 10)
            {
                if (average < 90)
                {
                    Console.WriteLine("IT'S TRUE");
                    return true;
                }
                //If average is below 130 execute the checksteadystate again with a higher watt(update timer)
                else
                {
                    Console.WriteLine("IT'S FALSE");
                    return false;
                }
            }
            else
            {
                //Check if there are invalid values in the pulseValues and filter them out
                //if after this check there's still no steady state you need to execute another 2 minutes of checksteadystate (update timer)
                Console.WriteLine("IT'S TRUE");
                return true;
            }
        }

        public void GetTime(Object source, ElapsedEventArgs e)
        {
            string timeString = ExerciseConnection.secondsTommss(this.Time);
            ExerciseConnection.SendTimeBike(timeString, MachineName);
            ExerciseConnection.SendTimeDoctor(timeString, MachineName);
            this.Time--;
        }

        public void BuildToTarget(Object source, ElapsedEventArgs e)
        {
            if (base.Power < base.Patient.TargettedWatt)
            {
                base.ExerciseConnection.SendInfoBike($"De weerstand is verhoogd naar { base.Power + 5}", 1);
                base.Power = base.Power + 5;
                base.ExerciseConnection.sendChangePower(base.Power, base.MachineName);
            }
            else
            {
                this.BuildToTargetTimer.Stop();
            }

        }
    }
}