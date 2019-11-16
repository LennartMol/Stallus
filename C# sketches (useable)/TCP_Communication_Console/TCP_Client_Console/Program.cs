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
            IPAddress ip = IPAddress.Parse("192.168.1.109"); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
            clientSock.Connect(ip, port);
            Console.WriteLine("Connected !");
            //string test = "DB_INSERT_REGISTRATE:TestFirst/TestLast/01_04_2001/test@test.nl/testpassword/Teststraat_1_0000NN_Test_Netherlands; DB_REQ_LOGIN:test@test.nl;";
            string test = "DB_UPDATE_DETAILS:email_address%first_name/;"; //DB_INSERT_REGISTRATE:TestFirst/TestLast/01_04_2001/test@test.nl/testpassword/Teststraat_1_0000NN_Test_Netherlands; DB_REQ_LOGIN:test@test.nl;
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
