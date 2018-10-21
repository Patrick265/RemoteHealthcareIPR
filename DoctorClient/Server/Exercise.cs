

        /// <summary>
        /// I assume they mean the targetted watt and the average heartrate of the steadystart
        /// </summary>
        /// <returns></returns>
        public double CalculateVO2Max()
        {
            if(patient.male)
            {
                return (0.00212 * this.patient.TargettedWat + 0.299) / (0.769 * this.AvgSteadyStartHeartRate - 48.5) * 1000;
            }
            else
            {
                return (0.00193 * this.patient.TargettedWat + 0.326) / (0.769 * this.AvgSteadyStartHeartRate - 56.1) * 1000;
            }
        }