using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;


namespace TCP_Client_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 13000;
            //TcpListener server;
            TcpClient clientSock = new TcpClient();
            Console.WriteLine("Connecting to Server ...");
            IPAddress ip = IPAddress.Parse("145.93.72.231");
            clientSock.Connect(ip, port);
            Console.WriteLine("Connected !");
            uint key = 7499;
            uint userid = 1;
            uint key_userid = key | (userid << 16);
            string test = $"DB_USER_UNLOCKED:;"; 
            NetworkStream stream = clientSock.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(test);
            Console.WriteLine($"Sending message to the Server: {test}");
            stream.Write(data, 0, data.Length);
            Byte[] bytes = new Byte[256];
            int i;
            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string data_ = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine("Received: {0}", data_);
            }
            Console.Read();
            //clientSock.Close();
        }
    }
}
