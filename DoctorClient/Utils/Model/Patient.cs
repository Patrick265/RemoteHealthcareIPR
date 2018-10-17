using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    public class Patient
    {
        public string name { get; set; }
        public float weight { get; set; }
        public int height { get; set; }
		public string date { get; set; }
        public List<TrainingSession> TrainingSessions { get; set; }
        public bool male { get; set; }

        public Patient(string name, float weight, int height, string date, List<TrainingSession> trainingSessions, bool male)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            this.date = date;
            this.male = male;
            this.TrainingSessions = trainingSessions;
            this.male = male;
        }

        public Patient()
        {
        }

        public override string ToString()
		{
			return $"Patient: \nName: {this.name}\nWeight: {this.weight}\nHeight: {this.height}\nDate: {this.date}";
		}
	}
}
