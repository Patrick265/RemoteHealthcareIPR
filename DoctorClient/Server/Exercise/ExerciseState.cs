using System.Collections.Generic;
using System;
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
            this.DurationWarmUp = 15000;
            this.DurationTrainingSession = 30000;
            this.DurationCooldown = 7000;
            this.ExerciseConnection = new ExerciseConnection(bikeStream, doctorStream);
            this.MachineName = MachineName;
            this.Patient = patient;
            this.AllowData = true;
        }

        public abstract void Event(Context context);

        public abstract void ChangeSession(object source, ElapsedEventArgs e);

        /// <summary>
        /// I assume they mean the targetted watt and the average heartrate of the steadystart
        /// </summary>
        /// <returns></returns>
        public double CalculateVO2Max()
        {
            if (this.Patient.male)
            {
                return 5; //(0.00212 * this.Patient.TargettedWat + 0.299) / (0.769 * this.AvgSteadyStartHeartRate - 48.5) * 1000;
            }
            else
            {
                return 5; // (0.00193 * this.Patient.TargettedWat + 0.326) / (0.769 * this.AvgSteadyStartHeartRate - 56.1) * 1000;
            }
        }
    }
}