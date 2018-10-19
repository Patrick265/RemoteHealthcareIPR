using System;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class TrainingState : ExerciseState
    {
        public Context Context { get; set; }
        public Timer timer;

        public TrainingState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
        }

        public override void Event(Context context)
        {
            this.Context = context;
           this.timer = new Timer(DurationTrainingSession);
           this.timer.Elapsed += new ElapsedEventHandler(ChangeSession);
           this.timer.Enabled = true;
            base.ExerciseConnection.SendInfoDoctor("De trainingsessie is begonnen, fiets met een RPM van 60!", base.MachineName);
            base.ExerciseConnection.SendInfoBike("De trainingsessie is begonnen, fiets met een RPM van 60!");
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            this.timer.Stop();
            this.Context.State = new CoolDownState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            this.Context.Request();
            Console.WriteLine(DateTime.Now + " Changed To Cooldown");
        }
    }
}