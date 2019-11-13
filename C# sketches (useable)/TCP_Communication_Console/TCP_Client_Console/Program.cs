using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCP_Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 13000;

            try
            {
                TcpClient clientSock = new TcpClient();
                Console.WriteLine("Connecting to Server ...");
                IPAddress ip = IPAddress.Parse("145.93.72.193"); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
                clientSock.Connect(ip, port);
                Console.WriteLine("Connected !");
                string test = "DB_INSERT_REGISTRATE:First/Last/01_04_2001/test@hotmail.nl/teststraat_10_5510TP_Veldhoven/password;";
                NetworkStream stream = clientSock.GetStream();
                byte[] data = Encoding.ASCII.GetBytes(test);
                Console.WriteLine($"Sending message to the Server: {test}");
                stream.Write(data, 0, data.Length);
                Console.Read();
                clientSock.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
