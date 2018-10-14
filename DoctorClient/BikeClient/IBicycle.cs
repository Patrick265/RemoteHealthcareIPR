using System;
using System.Collections.Generic;

namespace BikeClient
{
    interface IBicycle
    {
        bool ResetDevice();
        String RequestID();
        String RequestFirmwareVersion();
        Dictionary<String, String> RequestStatus();
        bool RequestCommandMode();
        bool RequestPower(int power, bool emergencyStop);
        bool RequestDistance(int distance);
        bool RequestTime(String time);
        void Disconnect();
    }
}