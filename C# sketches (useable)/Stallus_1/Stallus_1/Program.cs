using System;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.Security;

namespace Stallus_1
{
    class Program
    {
        private static int port = 13000;
        private static int maxThreads = 4;
        private static int dataTimeReadout = 5_000_000;
        private static int storageSize = 1024 * 256;
        static SocketProcess socketProcess;
        static SerialProcess serialProcess;
        private static string serverPassword = "password";
        private static void Main(string[] args)
        {
            socketProcess = new SocketProcess(port, maxThreads, dataTimeReadout, storageSize);
            Console.WriteLine("<Server>Stallus Server is on. Currently listening on " + "145.93.73.21" + ":" + port + "\n And waiting for Serial communication"); //GetIPAddress() //"145.93.73.139"
            Thread ipThread = new Thread(socketProcess.InitializeSocketProcessing);
            ipThread.Start();
            serialProcess = new SerialProcess('#', '%');
            Thread serialThread = new Thread(serialProcess.InitializeSerialProcessing);
            serialThread.Start();
            Thread commandThread = new Thread(CommandCentre);
            commandThread.Start();
        }
        private static void CommandCentre()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "scrash")
                {
                    SecureString masked = MaskInputString();
                    string Password = new NetworkCredential(string.Empty, masked).Password;
                    if (Password == serverPassword)
                    {
                        Console.Write("\n<Server>Server is shutting down.");
                        for (int i = 0; i <= 3; i++)
                        {
                            Thread.Sleep(400);
                            Console.Write(".");
                        }
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("\nWrong");
                        CommandCentre();
                    }
                }
            }
        }
        private static SecureString MaskInputString()
        {
            Console.WriteLine("<CommandCentre>Enter password");
            SecureString masked = new SecureString();
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);
                if (!char.IsControl(keyInfo.KeyChar))
                {
                    masked.AppendChar(keyInfo.KeyChar);
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && masked.Length > 0)
                {
                    masked.RemoveAt(masked.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return masked;
            }
        }
    }
}



