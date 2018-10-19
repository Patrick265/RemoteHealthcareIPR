using System;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class FinishedState : ExerciseState
    {
        public FinishedState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
        }

        public override void Event(Context context)
        {
            Console.WriteLine("In finished state");
            base.ExerciseConnection.SendInfoDoctor("De test is afgelopen!", base.MachineName);
            base.ExerciseConnection.SendInfoBike("De test is afgelopen!");
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
