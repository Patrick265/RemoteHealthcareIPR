using System;
using System.Timers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorClient
{
    class Exercise
    {
        Timer timer;
        int t = 0;
        
        public Exercise()
        {
            timer = new Timer(1000);
            timer.Elapsed += Elapsed;
            timer.Start();
            Start();
        }

        public void Start()
        {
           
        }

        public void Elapsed(Object source, ElapsedEventArgs e)
        {
            t++;
            if (t == 5)
            {
                Console.WriteLine("5 seconds gone by");
            }
        }
    }
}
