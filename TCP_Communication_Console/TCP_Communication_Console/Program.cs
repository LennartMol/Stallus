using System;
using System.Net.Sockets;
using System.IO;
using System.Net;
using System.Text;

namespace TCP_Communication_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World! I'm the Server " + GetIPAddress());
            TcpListener server = null;
            try
            {
                Int32 port = 13000;
                server = new TcpListener(GetIPAddress(), port);
                server.Start();
                Byte[] bytes = new Byte[256];
                String data = null;
                while (true)
                {
                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");
                    data = null;
                    NetworkStream stream = client.GetStream();
                    int i;
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        data = Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);
                        data = data.ToUpper();
                        byte[] msg = Encoding.ASCII.GetBytes(data);
                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }
                    client.Close();
                }
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }
            finally
            {
                server.Stop();
            }
            Console.WriteLine("\nHit enter to continue...");
            Console.Read();
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
