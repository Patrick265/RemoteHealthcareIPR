using System;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class WarmUpState : ExerciseState
    {
        public Context Context { get; set; }
        public Timer timer;
        public Timer timerInfo;
        public int time;

        public WarmUpState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) : 
            base(bikeStream, doctorStream, Patient, MachineName)
        {

        }

        public override void Event(Context context)
        {
            this.time = 120;
            this.timerInfo = new Timer(1000);
            this.timerInfo.Elapsed += GetTime;
            this.timerInfo.Enabled = true;
            this.Context = context;
            this.timer = new Timer(DurationWarmUp);
            this.timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.timer.Enabled = true;
            base.ExerciseConnection.SendChangeTime("0200", base.MachineName);
            base.ExerciseConnection.SendInfoDoctor("Fiets 2 minuten lang op een rustig tempo", base.MachineName, 1);
            base.ExerciseConnection.SendInfoBike("Fiets 2 minuten lang op een rustig tempo", 1);
            base.ExerciseConnection.sendChangePower(50, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            this.timerInfo.Stop();
            this.timer.Stop();
            Context.State = new TrainingState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            Context.Request();
            Console.WriteLine(DateTime.Now + " Changing to TrainingState");
        }

        public void GetTime(Object source, ElapsedEventArgs e)
        {
            string timeString = ExerciseConnection.secondsTommss(this.time);
            Console.WriteLine("TIME: " + timeString);
            ExerciseConnection.SendTimeBike(timeString, MachineName);
            ExerciseConnection.SendTimeDoctor(timeString, MachineName);
            time--;
        }
    }
}