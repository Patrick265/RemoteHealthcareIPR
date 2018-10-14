
using System;
using System.Collections.Generic;
using System.Threading;

namespace BikeClient
{
    class Simulator : IBicycle
    {
        private bool commandMode;
        private int power;
        private string ID;
        private string firmwareVersion;
        private double distance;
        private double energy;
        private int speed;
        private double RPM;
        private Time startTime;
        private Time time;
        private bool increment;
        private int requestedPower;
        private int pulse;

        public Simulator(int seconds)
        {
            commandMode = false;
            power = 25;
            ID = "SF1B1706";
            firmwareVersion = "117";
            distance = 10.0;
            energy = 100;
            speed = 200;
            RPM = speed * 3;
            time = new Time(seconds);
            startTime = new Time(seconds);
            increment = seconds <= 0;
            requestedPower = 100;
            pulse = 100;
        }

        public bool RequestCommandMode()
        {
            commandMode = true;
            new Thread(() =>
            {
            Thread.CurrentThread.IsBackground = true;
                while (commandMode)
                {
                    Console.WriteLine(speed / 3600.0);
                    distance += speed / 3600.00;
                    Thread.Sleep(1000);

                    lock (time)
                    {
                        bool parseds = int.TryParse(time.ToString().Split(':')[1], out int results);
                        bool parsedm = int.TryParse(time.ToString().Split(':')[0], out int resultm);
                        if (parseds && parsedm && results == 0 && resultm == 0)
                        {
                            increment = true;
                            time = startTime;
                        }

                        if (increment)
                            time.Increment(1);
                        else
                            time.Increment(-1);
                    }
                    //Console.WriteLine("tijd: " + time.ToString() + "\n" + "afstand: " + distance + "\npower: " + power);
                    if (requestedPower > power) power += 5;
                    else if (requestedPower < power) power -= 5;

                    speed += new Random().Next(0, 21) - 10;
                    if (speed < 0) speed += 11;
                    if (speed > 400) speed -= 20;

                    //calculating energy
                    double G = 9.8;
                    double slope = 0;
                    int M = 80;
                    int m = 20;
                    double Fg = G * Math.Sin(Math.Tan(slope)) * (M + m);
                    double Crr = 0.0063;
                    double Fr = G * Math.Cos(Math.Tan(slope)) * (M + m) * Crr;
                    double v = speed / 10.0 / 3.6;
                    double CdA = 0.408;
                    int h = 0;
                    double ρ = 1.225 * Math.Exp(-0.00011856 * h);
                    double w = 1;
                    double Fa = 0.5 * CdA * ρ * Math.Pow(v + w, 2);
                    double loss = 0.04;
                    energy = (Fg + Fr + Fa) * v / (1 - loss);
                }
            }
            ).Start();
            return true;
        }

        public bool RequestDistance(int distance)
        {
            if (commandMode) this.distance = distance / 10.0;
            return commandMode;
        }

        public string RequestFirmwareVersion()
        {
            return firmwareVersion;
        }

        public string RequestID()
        {
            return ID;
        }

        public bool RequestPower(int power, bool emergencyStop)
        {
            power = power - power % 5;
            if (emergencyStop) power = 25;
            if (commandMode) this.requestedPower = power;
            return commandMode;
        }

        public Dictionary<string, string> RequestStatus()
        {
            Dictionary<String, String> data = new Dictionary<String, String>
            {
                { "pulse", pulse.ToString() },
                { "rpm", RPM.ToString() },
                { "speed", speed.ToString() },
                { "distance", Math.Floor(distance * 10).ToString() },
                { "requested_power", requestedPower.ToString() },
                { "energy", ((int)energy).ToString() },
                { "mmss", time.ToString() },
                { "actual_power", power.ToString() }
            };

            return data;
        }

        public bool ResetDevice()
        {
            power = 25;
            distance = 0;
            return true;
        }

        public bool RequestTime(String time)
        {
            lock (time)
            {
                if (!commandMode) return false;
                this.time.setFromMMSS(time);
                return true;
            }
        }

        public void Disconnect()
        {
        }
    }
}