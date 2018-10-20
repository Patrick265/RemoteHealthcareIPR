using System;
using System.Collections.Generic;
using System.Text;

namespace Utils.Model
{
    public class AstrandData
    {
        public int Rpm { get; set; }
        public int Pulse { get; set; }
        public int Power { get; set; }

        public AstrandData(int rpm, int pulse, int power)
        {
            Rpm = rpm;
            Pulse = pulse;
            Power = power;
        }

        public AstrandData()
        {

        }
    }
}
