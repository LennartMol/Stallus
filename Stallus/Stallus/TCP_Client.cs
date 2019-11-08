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
        private string receivedMessage;

        public int Port { get; private set; }
        public string ReceivedMessage { get; private set; }

        public TCP_Client()
        {
            Port = 13000;
        }

        public void sendMessage(string message)
        {
            clientSock = new TcpClient();
            IPAddress ip = IPAddress.Parse("145.93.72.151");
            clientSock.Connect(ip, Port);
            NetworkStream stream = clientSock.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            clientSock.Close();
        }

        public bool getMessage()
        {
            byte[] bytes = new byte[1024];

            clientSock = new TcpClient();
            Console.WriteLine("Connecting to Server ...");
            IPAddress ip = IPAddress.Parse("145.93.72.151"); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
            clientSock.Connect(ip, Port);
            Console.WriteLine("Connected !");
            NetworkStream stream = clientSock.GetStream();
            stream = clientSock.GetStream();
            int num = stream.Read(bytes, 0, bytes.Length);
            ReceivedMessage = Encoding.ASCII.GetString(bytes, 0, num);
            clientSock.Close();
            if (!string.IsNullOrWhiteSpace(ReceivedMessage))
            {
                return true;
            }
            else return false;
            
        }

    }
}
