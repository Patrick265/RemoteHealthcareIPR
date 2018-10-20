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
        public int TargettedWatt { get; set; }
        public int age { get; set; }
        public int MaxHeartRate { get; set; }
        public double CorrectionFactor { get; set; }

        public Patient(string name, float weight, int height, string date, List<TrainingSession> trainingSessions, bool male)
        {
            this.name = name;
            this.weight = weight;
            this.height = height;
            this.date = date;
            this.male = male;
            this.TrainingSessions = trainingSessions;
            this.male = male;
            GenerateTargetedWatt();
            CalculateAge();
            CalcMaxHeartRate();
        }

        public Patient()
        {
        }

        public void GenerateTargetedWatt()
        {
            if(male)
            {
                if (this.age < 35)
                {
                    this.TargettedWatt = 125;
                }
                else if (this.age >= 35 && this.age < 55)
                {
                    this.TargettedWatt = 115;
                } 
                else
                {
                    this.TargettedWatt = 85;
                }
            } else
            {
                if (this.age < 35)
                {
                    this.TargettedWatt = 115;
                }
                else if (this.age >= 35 && this.age < 55)
                {
                    this.TargettedWatt = 85;
                }
                else
                {
                    this.TargettedWatt = 60;
                }
            }
        }

        public void CalculateAge()
        {

            string[] splitted = date.Split(@".".ToCharArray());
            int year = Convert.ToInt32(splitted[2]);
            int month = Convert.ToInt32(splitted[1]);
            int day = Convert.ToInt32(splitted[0]);
            DateTime time = new DateTime(year, month, day);
            this.age = DateTime.Now.Year - time.Year;
        }

        public void CalcMaxHeartRate()
        {
            if(this.age <= 24)
            {
                this.MaxHeartRate = 210;
                this.CorrectionFactor = 1.10;
            } 
            if(this.age >= 25 && this.age < 35)
            {
                this.MaxHeartRate = 200;
                this.CorrectionFactor = 1.00;
            }
            if (this.age >= 35 && this.age < 40)
            {
                this.MaxHeartRate = 190;
                this.CorrectionFactor = 0.87;
            }
            if (this.age >= 40 && this.age < 45)
            {
                this.MaxHeartRate = 180;
                this.CorrectionFactor = 0.83;
            }
            if (this.age >= 45 && this.age < 50)
            {
                this.MaxHeartRate = 170;
                this.CorrectionFactor = 0.78;
            }
            if (this.age >= 50 && this.age < 55)
            {
                this.MaxHeartRate = 160;
                this.CorrectionFactor = 0.75;
            }
            if (this.age >= 55)
            {
                this.MaxHeartRate = 150;
                this.CorrectionFactor = 71;
            }
            if (this.age >= 60)
            {
                this.MaxHeartRate = 150;
                this.CorrectionFactor = 0.68;
            }
            if (this.age >= 65)
            {
                this.MaxHeartRate = 150;
                this.CorrectionFactor = 0.65;
            }
        }

        public override string ToString()
        {
            return $"Patient: \nName: {this.name}\nWeight: {this.weight}\nHeight: {this.height}\nDate: {this.date}\nAge: {this.age}";
        }
    }
}
