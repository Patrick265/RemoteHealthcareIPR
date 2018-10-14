using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    public class TrainingSession
    {
        public string date;

        public TrainingSession(DateTime date)
        { 
            this.date = date.ToString();
        }

        public TrainingSession(string date)
        {
            this.date = date;
        }
    }
}
