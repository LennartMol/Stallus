using System;
using System.Text;
using System.Net.Sockets;
using System.Net;

namespace TCP_MultiThreadServer_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpListener serverSocket = null;
            Int32 port = 13000;
            //IPAddress IP_Address = IPAddress.Parse("169.254.23.36");
            serverSocket = new TcpListener(GetIPAddress(), port); //Mine 145.93.73.179 Marc 145.93.85.114 Home 169.254.23.36
            serverSocket.Start();
            
            TcpClient clientSocket = null;
            
            Console.WriteLine(" >> " + "Server Started");
            int counter = 0;
            while (true)
            {
                counter += 1;
                clientSocket = serverSocket.AcceptTcpClient();
                Console.WriteLine(" >> " + "Client No:" + Convert.ToString(counter) + " started!");
                HandleClient client = new HandleClient();
                client.StartClient(clientSocket, Convert.ToString(counter));
            }
            //clientSocket.Close();
            //serverSocket.Stop();
            //Console.WriteLine(" >> " + "exit");
            //Console.ReadLine();
        }
        public static IPAddress GetIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Environment.MachineName);
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address;
            }
            return null;
        }
    }
}
