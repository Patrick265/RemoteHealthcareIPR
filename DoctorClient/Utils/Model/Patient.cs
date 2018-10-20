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
        public int TargettedWat { get; set; }
        public int age { get; set; }
        public int MaxHeartRate { get; set; } 

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
                    this.TargettedWat = 125;
                }
                else if (this.age >= 35 && this.age < 55)
                {
                    this.TargettedWat = 115;
                } 
                else
                {
                    this.TargettedWat = 85;
                }
            } else
            {
                if (this.age < 35)
                {
                    this.TargettedWat = 115;
                }
                else if (this.age >= 35 && this.age < 55)
                {
                    this.TargettedWat = 85;
                }
                else
                {
                    this.TargettedWat = 60;
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
            } 
            if(this.age >= 25 && this.age < 35)
            {
                this.MaxHeartRate = 200;
            }
            if (this.age >= 35 && this.age < 40)
            {
                this.MaxHeartRate = 190;
            }
            if (this.age >= 40 && this.age < 45)
            {
                this.MaxHeartRate = 180;
            }
            if (this.age >= 45 && this.age < 50)
            {
                this.MaxHeartRate = 170;
            }
            if (this.age >= 50 && this.age < 55)
            {
                this.MaxHeartRate = 160;
            }
            if (this.age >= 55)
            {
                this.MaxHeartRate = 150;
            }
        }

        public override string ToString()
        {
            return $"Patient: \nName: {this.name}\nWeight: {this.weight}\nHeight: {this.height}\nDate: {this.date}\nAge: {this.age}";
        }
    }
}
