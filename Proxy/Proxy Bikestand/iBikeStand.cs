using System;
using System.Collections.Generic;
using System.Text;

namespace Proxy_Bikestand
{
    interface iBikeStand
    {
        public int BaudRate { get; }
        string PortName { get; }
        bool IsDisconnected { get; }


        void Connect();
        void Disconnect();
        string[] GetAvailablePortNames();
        bool IsConnected();
        bool SendMessage(string message);
        string[] ReadMessages();
    }
}
