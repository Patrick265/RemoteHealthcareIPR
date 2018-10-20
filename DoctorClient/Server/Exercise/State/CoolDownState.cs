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

        public CoolDownState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
        }

        public override void Event(Context context)
        {
            this.Context = context;
            this.timer = new Timer(DurationTrainingSession);
            this.timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.timer.Enabled = true;
            base.ExerciseConnection.SendInfoDoctor("De cooldown is begonnen, fiets op een rustig tempo door", base.MachineName);
            base.ExerciseConnection.SendInfoBike("De cooldown is begonnen, fiets op een rustig tempo door");
            base.ExerciseConnection.sendChangePower(50, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            this.timer.Stop();
            Console.WriteLine(DateTime.Now + " Changed To FinishState");
            this.Context.State = new FinishedState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            this.Context.Request();
        }
    }
}