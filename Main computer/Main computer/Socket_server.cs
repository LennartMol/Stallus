using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Main_computer
{
    class Socket_server
    {
        TcpListener servSock = null;
        TcpClient clientSock = null;
        byte[] bytes = new byte[1024];
        IPAddress ipAddress;

        public int Port { get; private set; }

        public Socket_server()
        {
            Port = 13000;
            GetLocalIPAddress();
        }

        public void GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = IPAddress.Parse(ip.ToString());
                }
            }
        }

        public void startServer()  
        {
            servSock = new TcpListener(ipAddress, Port);
            servSock.Start();
        }

        public string receiveMessage()
        {
            clientSock = new TcpClient();
            clientSock = servSock.AcceptTcpClient();
            NetworkStream stream = clientSock.GetStream();
            int num = stream.Read(bytes, 0, bytes.Length);
            string message = Encoding.ASCII.GetString(bytes, 0, num);
            clientSock.Close();
            return message;
        }
    }
}
