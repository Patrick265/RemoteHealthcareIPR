﻿using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Timers;
using Utils.Model;

namespace Server.Exercise.State
{
    public class FinishedState : ExerciseState
    {
        public FinishedState(NetworkStream bikeStream, NetworkStream doctorStream, Patient Patient, string MachineName) :
            base(bikeStream, doctorStream, Patient, MachineName)
        {
        }

        public override void Event(Context context)
        {
            Console.WriteLine("In finished state");
            base.AllowData = false;
            ExerciseConnection.SendTimeBike("00:00", MachineName);
            ExerciseConnection.SendTimeDoctor("00:00", MachineName);
            base.ExerciseConnection.SendChangeTime("0000", base.MachineName);
            base.ExerciseConnection.SendInfoDoctor("De test is afgelopen!", base.MachineName, 1);
            base.ExerciseConnection.SendInfoBike("De test is afgelopen!", 1);
            base.ExerciseConnection.sendChangePower(25, base.MachineName);
        }

        public override void ChangeSession(object source, ElapsedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}
