using System;

namespace BikeClient
{
    class Time
    {
        private int seconds;

        public Time(int seconds)
        {
            this.seconds = seconds;
        }

        public void Increment(int i)
        {
            this.seconds += i;
            if (this.seconds < 0)
                this.seconds = 0;
        }

        public override string ToString()
        {
            return  ((seconds-seconds%60)/60).ToString("00") + ":" + (seconds%60).ToString("00");
        }

        public void setFromMMSS(String MMSS)
        {
            int minutes = Convert.ToInt32(MMSS.Substring(0, 2));
            int seconds = Convert.ToInt32(MMSS.Substring(2, 2));
            this.seconds = minutes * 60 + seconds;
        }
    }
}