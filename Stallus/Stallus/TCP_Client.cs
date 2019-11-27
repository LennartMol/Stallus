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
        public IPAddress IPAddress { get; private set; }
        public int Port { get; private set; }
        public string ReceivedString { get; private set; }
        public string[] ReceivedData { get; set; }

        public TCP_Client(IPAddress ip)
        {
            IPAddress = ip;
            Port = 13000;
        }

        public bool CheckConnection()
        {
            try
            {
                clientSock.Connect(IPAddress, Port);
                clientSock.Close();
                clientSock.Dispose();
                return true;
            }
            catch
            {
                return false;
            }
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
            ReceivedString = Encoding.ASCII.GetString(bytes, 0, num);
            clientSock.Close();
            return !string.IsNullOrWhiteSpace(ReceivedString);
        }


        public void MessageHandler()
        {
            if (GetMessage())
            {
                if (ReceivedString.StartsWith("ACK"))
                {
                    ReceivedString = ReceivedString.Substring(ReceivedString.IndexOf('_') + 1);
                    ReceivedData = CommandStringTrimmer(ReceivedString);
                }
            }
        }

        public DateTime ConvertStringToDateTime(string datetimeString)
        {
            string[] data = new string[3];
            data[0] = datetimeString.Remove(datetimeString.IndexOf('-'));
            data[1] = datetimeString.Substring(datetimeString.IndexOf('-') + 1).Remove(datetimeString.IndexOf('-') - 2);
            data[2] = datetimeString.Substring(datetimeString.IndexOf('-')).Substring(datetimeString.IndexOf('-'));
            DateTime dateTime = new DateTime(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]));
            return dateTime;
        }



        public Address GetAddress(string address)
        {
            List<int> commaindexes = CommaIndexes(address);
            string street = address.Substring(0, address.IndexOf(' '));
            string number = address.Substring(street.Length + 1, commaindexes[0] - street.Length - 1);
            string zipcode = address.Substring(commaindexes[0] + 2, commaindexes[1] - commaindexes[0] - 2);
            string city = address.Substring(commaindexes[1] + 2, commaindexes[2] - commaindexes[1] - 2);
            string country = address.Substring(commaindexes[2] + 2);
            return new Address(street, number, zipcode, city, country);
        }

        private List<int> CommaIndexes(string s)
        {
            List<int> indexes = new List<int>();
            char[] s_array = s.ToCharArray();
            for (int i = 0; i < s_array.Length; i++)
            {
                if (s_array[i] == ',')
                {
                    indexes.Add(i);
                }
            }
            return indexes;
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
