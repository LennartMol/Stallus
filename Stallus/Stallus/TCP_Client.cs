﻿using System;
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
        public string ReceivedMessage { get; private set; }

        public TCP_Client()
        {
            Port = 13000;
        }

        public void SendMessage(string message)
        {
            clientSock = new TcpClient();
            IPAddress ip = IPAddress.Parse("145.93.72.193");
            clientSock.Connect(ip, Port);
            NetworkStream stream = clientSock.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            clientSock.Close();
        }

        public bool GetMessage()
        {
            byte[] bytes = new byte[1024];

            clientSock = new TcpClient();
            Console.WriteLine("Connecting to Server ...");
            IPAddress ip = IPAddress.Parse("145.93.72.193"); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
            clientSock.Connect(ip, Port);
            Console.WriteLine("Connected !");
            NetworkStream stream = clientSock.GetStream();
            stream = clientSock.GetStream();
            int num = stream.Read(bytes, 0, bytes.Length);
            ReceivedMessage = Encoding.ASCII.GetString(bytes, 0, num);
            clientSock.Close();
            return !string.IsNullOrWhiteSpace(ReceivedMessage);
        }


        public string[] MessageHandler()
        {
            //if (GetMessage())
            //{
            ReceivedMessage = "ACK_REQ_LOGIN:USERNAME/PASSWORD";
                if (ReceivedMessage.StartsWith("ACK"))
                {
                    ReceivedMessage = ReceivedMessage.Substring(ReceivedMessage.IndexOf('_') + 1);
                    Console.WriteLine(ReceivedMessage);
                    return CommandStringTrimmer(ReceivedMessage);
                }

                //ACK_REQ_LOGIN:USERNAME/PASSWORD
            //}
            return null;
        }

        public string[] CommandStringTrimmer(string stringToTrim)
        {
            if (!stringToTrim.Contains("/"))
            {
                return new string[] { stringToTrim.Substring(stringToTrim.IndexOf(':') + 1) };
            }
            return stringToTrim.Substring(stringToTrim.IndexOf(':') + 1).Split('/');
        }


    }
}
