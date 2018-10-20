using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class TrainingState : ExerciseState
    {
        private Context Context;
        private Timer Timer;
        private Timer PulseTimer;
        private int Counter;
        private Dictionary<DateTime, double> PulseSecond;
        private Dictionary<DateTime, double> PulseMinute;

        public TrainingState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
            this.Counter = 0;
            this.PulseSecond = new Dictionary<DateTime, double>();
            this.PulseMinute = new Dictionary<DateTime, double>();
            this.Timer = new Timer(DurationTrainingSession);
            this.PulseTimer = new Timer(15000);
        }

        public override void Event(Context context)
        {
            this.Context = context;
            this.Timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.Timer.Enabled = true;
            this.PulseTimer.Elapsed += new ElapsedEventHandler(DataRetriever);
            this.PulseTimer.Enabled = true;

            base.ExerciseConnection.SendChangeTime("0030", base.MachineName);
            base.ExerciseConnection.SendInfoDoctor("De trainingsessie is begonnen, fiets met een RPM van 60!", base.MachineName);
            base.ExerciseConnection.SendInfoBike("De trainingsessie is begonnen, fiets met een RPM van 60!");
            base.ExerciseConnection.sendChangePower(base.Patient.TargettedWat, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            this.PulseTimer.Stop();
            this.Timer.Stop();
            Console.WriteLine("MINUTE: " + this.PulseMinute.Count);
            Console.WriteLine("SECOND: " + this.PulseSecond.Count);
            this.Context.State = new CoolDownState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            this.Context.Request();
            Console.WriteLine(DateTime.Now + " Changed To Cooldown");
        }

        public void DataRetriever(object source, ElapsedEventArgs e)
        {
            if(base.Pulse > base.Patient.MaxHeartRate)
            {
                this.PulseTimer.Stop();
                this.Timer.Stop();
                this.Context.State = new FinishedState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
                this.Context.Request();
            }
            if (this.Counter == 3 || this.Counter == 7)
            {
                this.PulseMinute.Add(DateTime.Now, base.Pulse);
            }
            if(this.Counter > 7 )
            {
                this.PulseSecond.Add(DateTime.Now, base.Pulse);
            }
            this.Counter++;
        }



        public void GetAverageHeartRate()
        {
            throw new NotImplementedException();
        }
    }
}