using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;

namespace Main_computer
{
    public class SocketProcess
    {
        public IPAddress IPAddress { get; private set; }
        public int Port { get; private set; }
        public int MaxThreads { get; private set; }
        public int DataTimeReadout { get; private set; }
        public int StorageSize { get; private set; }
        private string prefix = "<SocketProcess>";
        public SocketProcess(IPAddress iPAddress, int port, int maxThreads, int dataTimeReadout, int storageSize)
        {
            if (port < 1)
            {
                throw new ArgumentException("Port cannot be zero", "port");
            }
            IPAddress = iPAddress;
            Port = port;
            MaxThreads = maxThreads;
            DataTimeReadout = dataTimeReadout;
            StorageSize = storageSize;
        }
        private static WaitHandle[] waitHandles;
        private static Socket listener;
        private struct ThreadParams
        {
            public AutoResetEvent ThreadHandle;
            public Socket ClientSocket;
            public int ThreadIndex;
        }
        public void InitializeSocketProcessing()
        {
            waitHandles = new WaitHandle[MaxThreads];
            for (int i = 0; i < MaxThreads; ++i)
            {
                waitHandles[i] = new AutoResetEvent(true);
            }

            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress, Port)); //GetIPAddress() // IPAddress.Parse("145.93.73.139")
            listener.Listen(25);

            while (true)
            {
                Console.WriteLine($"{prefix}Waiting for a TCP connection");
                Socket sock = listener.Accept();

                Console.WriteLine($"{prefix}Got a connection");
                Console.WriteLine($"{prefix}Waiting for idle thread");
                int index = WaitHandle.WaitAny(waitHandles);

                Console.WriteLine($"{prefix}Starting new thread to process client");

                ThreadParams context = new ThreadParams()
                {
                    ThreadHandle = (AutoResetEvent)waitHandles[index],
                    ClientSocket = sock,
                    ThreadIndex = index
                };
                ThreadPool.QueueUserWorkItem(ProcessSocketConnection, context);
            }
        }
        public IPAddress GetIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Environment.MachineName);
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address;
            }
            return null;
        }

        public bool CheckDbReachable()
        {
            Database db = new Database();
            return db.IsDatabaseReachable();
        }

        public void ProcessSocketConnection(object threadState)
        {
            ThreadParams state = (ThreadParams)threadState;
            Console.WriteLine($"{prefix}Thread {state.ThreadIndex} is processing connection"); //{state.ClientSocket.RemoteEndPoint}

            // This should be an extra method. In general this code should be more modular!
            byte[] recievBuffer = new byte[StorageSize];
            if (state.ClientSocket.Poll(DataTimeReadout, SelectMode.SelectRead))
            {
                state.ClientSocket.Receive(recievBuffer);
            }
            else
            {
                Console.WriteLine($"{prefix}Got no data, aborting");
                Cleanup();
            }
            // Do your data Processing in this Method.
            DoWork(recievBuffer, state.ClientSocket);
            Cleanup();
            // This is a local Function introduced in c#7
            void Cleanup()
            {
                Console.WriteLine($"{prefix}Doing clean up tasks.");
                state.ClientSocket.Shutdown(SocketShutdown.Both);
                state.ClientSocket.Close();
                state.ClientSocket.Dispose();

                recievBuffer = new byte[StorageSize];

                state.ThreadHandle.Set();
            }
        }
        private void DoWork(byte[] context, Socket socket)
        {
            string command = Encoding.ASCII.GetString(context);
            string cleanCommand = command.Substring(0, command.IndexOf(';') + 1);
            Console.WriteLine(cleanCommand);
            if (cleanCommand.StartsWith("DB"))
            {
                DatabaseCommandsHandler(cleanCommand.Substring(3), socket);
            }
            else if (cleanCommand.StartsWith("ARD"))
            {

            }
        }

        private string[] CommandStringTrimmer(string stringToTrim)
        {
            if (!stringToTrim.Contains("/"))
            {
                 return new string[] { stringToTrim.Substring(stringToTrim.IndexOf(':') + 1) };
            }
            return stringToTrim.Substring(stringToTrim.IndexOf(':') + 1).Split('/');
        }

        private void DatabaseCommandsHandler(string protocol, Socket socket)
        {
            Database db = new Database();
            if (db.IsDatabaseReachable())
            {
                string[] data = CommandStringTrimmer(protocol);
                if (protocol.StartsWith("INSERT_REGISTRATE"))
                {
                    string first_name = data[0];
                    string last_name = data[1];
                    DateTime date_of_birth = ParseDateTime(data[2]);
                    string email_address = data[3];
                    Address address = ParseAddress(data[4]);
                    string password = data[5].Substring(0, data[5].Length - 1);
                    db.Registrate(first_name, last_name, date_of_birth, email_address, address, password);
                }
                else if (protocol.StartsWith("REQ_LOGIN"))
                {
                    string username = data[0];
                    string password = db.RetrievePassword(username);
                    string send = $"ACK_REQ_LOGIN:{username}/{password}";
                    socket.Send(Encoding.ASCII.GetBytes(send));
                }
            }
            else
            {
                Console.WriteLine($"{prefix}Received command for Database-data, but can not reach Database.\nServer is not connected to 'vdi.fhict.nl' via a VPN connection");
            }
        }

        private DateTime ParseDateTime(string date)
        {
            List<int> divisor_indexes = GetDivisorIndexes(date);

            int year = Convert.ToInt32(date.Substring(divisor_indexes[1] + 1));
            int month = Convert.ToInt32(date.Substring(divisor_indexes[0] + 1, divisor_indexes[1] - divisor_indexes[0] - 1));
            int day = Convert.ToInt32(date.Substring(0, divisor_indexes[0]));
            return new DateTime(year, month, day);
        }

        private Address ParseAddress(string address)
        {
            List<int> divisor_indexes = GetDivisorIndexes(address);
            string street = address.Substring(0, divisor_indexes[0]);
            string number = address.Substring(divisor_indexes[0] + 1, divisor_indexes[1] - divisor_indexes[0] - 1);
            string zipcode = address.Substring(divisor_indexes[1] + 1, divisor_indexes[2] - divisor_indexes[1] - 1);
            string city = address.Substring(divisor_indexes[2] + 1);
            Console.WriteLine(street + number + zipcode + city);
            return new Address(street, number, zipcode, city);
        }

        private List<int> GetDivisorIndexes(string data)
        {
            List<int> divisor_indexes = new List<int>();
            char[] data_charArray = data.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                if (data_charArray[i] == '_')
                {
                    divisor_indexes.Add(i);
                }
            }
            return divisor_indexes;
        }
    }
}
