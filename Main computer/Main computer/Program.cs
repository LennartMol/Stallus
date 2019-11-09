using System;
using System.IO;
using System.IO.Ports;
using System.Net.Sockets;
using System.Threading;
using System.Net;
using System.Text;
using System.Security;
using System.Collections.Generic;

namespace Main_computer
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
        private static string serverPrefix = "<Server>";
        private static string errorPrefix = "<Error>";
        private static IPAddress chosenIpAdress = null;
        private static string chosenPortName = "";
        private static void Main(string[] args)
        {
            Console.WriteLine($"{serverPrefix}Stallus Server is running, but not yet online for communication."); //GetIPAddress() //"145.93.73.139"
            Thread commandThread = new Thread(CommandCentre);
            commandThread.Start();
        }

        private static void StartSocketProcess()
        {
            try
            {
                socketProcess = new SocketProcess(chosenIpAdress, port, maxThreads, dataTimeReadout, storageSize);
                Console.WriteLine($"{serverPrefix}SocketProcess started"); //GetIPAddress() //"145.93.73.139"
                Thread ipThread = new Thread(socketProcess.InitializeSocketProcessing);
                ipThread.Start();
            }
            catch (Exception x)
            {
                Console.WriteLine(errorPrefix + x.Message);
            }
        }

        private static void StartSerialProcess()
        {
            try
            {
                serialProcess = new SerialProcess('#', '%', chosenPortName);
                Thread serialThread = new Thread(serialProcess.InitializeSerialProcessing);
                serialThread.Start();
            }
            catch (Exception x)
            {
                Console.WriteLine(errorPrefix + x.Message);
            }
        }

        private static void CommandCentre()
        {
            string[] commands = { "scrash", "config", "config socket", "config serial", "socket start", "serial start", "help", string.Empty };
            while (true)
            {
                string command = Console.ReadLine();
                bool commandExists = CheckIfCommandExists(commands, command);
                if (commandExists)
                {
                    if (command == "scrash")
                    {
                        SecureString masked = MaskInputString();
                        string Password = new NetworkCredential(string.Empty, masked).Password;
                        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
                        if (Password == serverPassword)
                        {
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.WriteLine($"\n{serverPrefix}Wrong");
                            CommandCentre();
                        }
                    }
                    else if (command == "config")
                    {
                        Console.WriteLine("config [socket/serial] <?>");
                    }
                    else if (command == "config socket")
                    {
                        string hostName = Dns.GetHostName();
                        IPAddress[] ipList = Dns.GetHostEntry(hostName).AddressList;
                        Console.WriteLine($"{serverPrefix}Possible ip-addresses for {hostName}:");
                        IPAddress[] cleanIpList = new IPAddress[10];
                        int j = 0;
                        //foreach (IPAddress ip in ipList)
                        //{
                        //    //if (ip.AddressFamily == AddressFamily.InterNetwork)
                        //    //{
                        //    //    cleanIpList[j] = ip;
                        //    //    j++;
                        //    //}
                        //}
                        foreach (IPAddress ip in ipList)
                        {
                            if (!ip.ToString().Contains("%"))
                            {
                                Console.WriteLine(ip.ToString());
                                cleanIpList[j] = ip;
                                j++;
                            }
                        }
                        chosenIpAdress = ChooseIpSetting(cleanIpList);
                        Console.WriteLine($"{serverPrefix}Chosen IP-Address: {chosenIpAdress.ToString()}.");
                        //else
                        //{
                        //    Console.WriteLine($"{serverPrefix}No IP-Addresses available. Server is using VPN");
                        //}
                    }
                    else if (command == "config serial")
                    {
                        string[] availablePortnames = SerialPort.GetPortNames();
                        Console.WriteLine($"{serverPrefix}Available ports:");
                        if (availablePortnames.Length != 0)
                        {
                            foreach (string portName in availablePortnames)
                            {
                                Console.WriteLine(portName);
                            }
                            chosenPortName = ChoosePortName(availablePortnames);
                            Console.WriteLine($"{serverPrefix}Chosen port-name: {chosenPortName}");
                        }
                        else
                        {
                            Console.WriteLine($"{serverPrefix}No available Ports");
                        }
                    }
                    else if (command == "socket start")
                    {
                        if (chosenIpAdress != null)
                        {
                            Console.WriteLine($"{serverPrefix}Starting SocketProcess with: {chosenIpAdress.ToString()}:{port}.");
                            StartSocketProcess();
                        }
                        else
                        {
                            Console.WriteLine($"{serverPrefix}No chosen IP-Address. Try choosing one by using command: config socket.");
                        }
                    }
                    else if (command == "serial start")
                    {
                        if (chosenPortName != "")
                        {
                            Console.WriteLine($"{serverPrefix}Starting SerialProcess with: {chosenPortName}");
                            StartSerialProcess();
                        }
                        else
                        {
                            Console.WriteLine($"{serverPrefix}No chosen Portname. Try choosing one by using command: config serial.");
                        }
                    }
                    else if (command == "help")
                    {
                        Console.WriteLine($"{serverPrefix}Existing commands:");
                        foreach (string existingCommand in commands)
                        {
                            Console.WriteLine(existingCommand);
                        }
                    }
                }
                else
                {
                    Console.WriteLine($"{serverPrefix}'{command}' is not a command.");
                }
            }
        }

        private static bool CheckIfCommandExists(string [] existingCommands, string command)
        {
            foreach (string existingCommand in existingCommands)
            {
                if (existingCommand == command)
                {
                    return true;
                }
            }
            return false;
        }

        private static SecureString MaskInputString()
        {
            Console.WriteLine($"{serverPrefix}Enter password");
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

        private static IPAddress ChooseIpSetting(IPAddress[] iPAddresses)
        {
            Console.WriteLine($"{serverPrefix}Choose Ip-Adress by using the UP/DOWN arrow keys");
            ConsoleKeyInfo keyInfo;
            int index = 0;
            Console.WriteLine(iPAddresses[index]);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    index++;
                    if (index > 4)
                    {
                        index = 0;
                    }
                    Console.WriteLine("                                    ");
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(iPAddresses[index]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    index--;
                    if (index < 0)
                    {
                        index = 4;
                    }
                    Console.WriteLine("                                    ");
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                    Console.WriteLine(iPAddresses[index]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return iPAddresses[index];
            }
        }

        private static string ChoosePortName(string[] availablePortNames)
        {
            Console.WriteLine($"{serverPrefix}Choose Portname by using the UP/DOWN arrow keys");
            ConsoleKeyInfo keyInfo;
            int index = 0;
            Console.WriteLine(availablePortNames[index]);
            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
            do
            {
                keyInfo = Console.ReadKey(true);
                if (keyInfo.Key == ConsoleKey.DownArrow)
                {
                    index--;
                    if (index < 0)
                    {
                        index = (availablePortNames.Length - 1);
                    }
                    Console.WriteLine(availablePortNames[index]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
                else if (keyInfo.Key == ConsoleKey.UpArrow)
                {
                    index++;
                    if (index > (availablePortNames.Length -1))
                    {
                        index = 0;
                    }
                    Console.WriteLine(availablePortNames[index]);
                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);
            {
                return availablePortNames[index];
            }
        }
    }
}



