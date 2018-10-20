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

        public WarmUpState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) : 
            base(bikeStream, doctorStream, Patient, MachineName)
        {

        }

        public override void Event(Context context)
        {
            this.Context = context;
            this.timer = new Timer(DurationWarmUp);
            this.timer.Elapsed += new ElapsedEventHandler(ChangeSession);
            this.timer.Enabled = true;

            base.ExerciseConnection.SendInfoDoctor("Fiets 2 minuten lang op een rustig tempo", base.MachineName);
            base.ExerciseConnection.SendInfoBike("Fiets 2 minuten lang op een rustig tempo");
            base.ExerciseConnection.sendChangePower(50, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            this.timer.Stop();
            Context.State = new TrainingState(base.ExerciseConnection.BikeStream, base.ExerciseConnection.DoctorStream, base.Patient, base.MachineName);
            Context.Request();
            Console.WriteLine(DateTime.Now + " Changing to TrainingState");
        }
    }
}