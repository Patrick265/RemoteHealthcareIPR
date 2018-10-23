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
        public int Rpm { get; set; }
        public int Pulse { get; set; }
        public int Power { get; set; }
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
            this.DurationWarmUp = 122000;
            this.DurationTrainingSession = 242000;
            this.DurationCooldown = 62000;
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
        public double CalculateVO2Max(double AverageHeartBeat)
        {
            if (this.Patient.male)
            {
                return ((0.00212 * (this.Patient.TargettedWatt * 6.1182972778676) + 0.299) / (0.769 * AverageHeartBeat - 48.5) * 100) * this.Patient.CorrectionFactor;
            }
            else
            {
                return  ((0.00193 * (this.Patient.TargettedWatt * 6.1182972778676)+ 0.326)  / (0.769 * AverageHeartBeat - 56.1) * 100) * this.Patient.CorrectionFactor;
            }
        }

        public void CheckRPM()
        {
            Console.WriteLine("RPM: " + this.Rpm);
            if (this.Rpm < 50)
            {
                this.ExerciseConnection.SendInfoBike("U fietst niet hard genoeg, probeer" + Environment.NewLine + "rond de 60 rpm te blijven", 2);
                this.ExerciseConnection.SendInfoDoctor("De patient fietst te zacht en heeft een waarschuwing gekregen", this.MachineName, 2);
            }
            else if (this.Rpm > 70)
            {
                this.ExerciseConnection.SendInfoBike("U fietst te snel, probeer rond de" + Environment.NewLine + "60 rpm te blijven", 2);
                this.ExerciseConnection.SendInfoDoctor("De patient fietst te hard en heeft een waarschuwing gekregen", this.MachineName, 2);
            }
            else
            {
                this.ExerciseConnection.SendInfoBike("", 2);
                this.ExerciseConnection.SendInfoDoctor("", this.MachineName, 2);
            }
        }
    }
}