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
            string sendLine = "";
            const int port = 13000;
            byte[] bytes = new byte[1024];

            try
            {
                //Send
                if (Console.ReadLine() == "Connect to server")
                {
                    TcpClient clientSock = new TcpClient();
                    Console.WriteLine("Connecting to Server ...");
                    IPAddress ip = IPAddress.Parse("169.254.23.36"); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
                    clientSock.Connect(ip, port);
                    Console.WriteLine("Connected !");


                    while (sendLine != "Stop")
                    {
                        sendLine = Console.ReadLine();

                        NetworkStream stream = clientSock.GetStream();
                        byte[] data = Encoding.ASCII.GetBytes(sendLine);
                        Console.WriteLine("Sending message to the Server");
                        stream.Write(data, 0, data.Length);


                        //listen
                        stream = clientSock.GetStream();
                        int num = stream.Read(bytes, 0, bytes.Length);
                        Console.WriteLine(Encoding.ASCII.GetString(bytes, 0, num));
                    }

                    Console.WriteLine("Presss ANY key to quit");
                    Console.Read();
                    clientSock.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}
