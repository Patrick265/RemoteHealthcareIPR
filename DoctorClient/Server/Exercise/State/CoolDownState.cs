using System;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class CoolDownState : ExerciseState
    {
        public Context Context { get; set; }
        public Timer timer;
        public Timer timerInfo;
        public int time;

        public CoolDownState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {

        }

        public override void Event(Context context)
        {
            Console.WriteLine("IN COOLDOWN");
            this.time = 60;
            this.timerInfo = new Timer(1000);
            this.timerInfo.Elapsed += GetTime;
            this.timerInfo.Enabled = true;
            this.Context = context;
            this.timer = new Timer(DurationCooldown);
            this.timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.timer.Enabled = true;
            base.ExerciseConnection.SendChangeTime("0100", base.MachineName);
            base.ExerciseConnection.SendInfoDoctor("De cooldown is begonnen, fiets op een rustig tempo door", base.MachineName, 1);
            base.ExerciseConnection.SendInfoBike("De cooldown is begonnen, fiets op een rustig tempo door", 1);
            base.ExerciseConnection.sendChangePower(50, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            Console.WriteLine(DateTime.Now + " Changed To FinishState");
            this.timer.Stop();
            Console.WriteLine(DateTime.Now + " Changed To FinishState");
            this.Context.State = new FinishedState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            this.Context.Request();
        }

        public void GetTime(Object source, ElapsedEventArgs e)
        {
            string timeString = ExerciseConnection.secondsTommss(this.time);
            ExerciseConnection.SendTimeBike(timeString, MachineName);
            ExerciseConnection.SendTimeDoctor(timeString, MachineName);
            this.time--;
        }
    }
}