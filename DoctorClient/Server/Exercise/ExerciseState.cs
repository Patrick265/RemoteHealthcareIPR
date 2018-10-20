using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise
{
    public abstract class ExerciseState
    {
        #region Bike Data
        public Patient Patient;
        public string MachineName;
        public double Rpm { get; set; }
        public double Pulse { get; set; }
        public double Power { get; set; }
        public bool AllowData { get; set; }
        #endregion

        #region Duration Sessions
        public double DurationWarmUp { get; set; }
        public double DurationTrainingSession { get; set; }
        public double DurationCooldown { get; set; }
        #endregion

        public ExerciseConnection ExerciseConnection { get; set; }

        public ExerciseState(NetworkStream bikeStream, NetworkStream doctorStream, Patient patient, string MachineName)
        {
            this.DurationWarmUp = 10000;
            this.DurationTrainingSession = 10000;
            this.DurationCooldown = 10000;
            this.ExerciseConnection = new ExerciseConnection(bikeStream, doctorStream);
            this.MachineName = MachineName;
            this.Patient = patient;
            this.AllowData = true;
        }

        public abstract void Event(Context context);

        public abstract void ChangeSession(object source, ElapsedEventArgs e);
    }
}