using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Stallus
{
    class TCP_Client
    {
        TcpClient clientSock = null;

        public int Port { get; private set; }

        public TCP_Client()
        {
            Port = 13000;
        }

        public void sendMessage(string message)
        {
            clientSock = new TcpClient();
            clientSock.Connect(IPAddress.Loopback, Port);
            NetworkStream stream = clientSock.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            clientSock.Close();
        }
    }
}
