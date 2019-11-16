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
        private static WaitHandle[] waitHandles;
        private static Socket listener;
        private Utility utility;
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
            utility = new Utility();
        }
        
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
            Console.WriteLine("Received: " + cleanCommand);
            if (cleanCommand.StartsWith("DB"))
            {
                DatabaseCommandsHandler(cleanCommand.Substring(3), socket);
            }
            else if (cleanCommand.StartsWith("ARD"))
            {

            }
        }

        private void DatabaseCommandsHandler(string protocol, Socket socket)
        {
            Database db = new Database();
            if (db.IsDatabaseReachable())
            {
                string cleanProtocol = protocol.Substring(0, protocol.Length - 1);
                string[] data = utility.CommandStringTrimmer(cleanProtocol);
                if (protocol.StartsWith("INSERT_REGISTRATE"))
                {
                    string first_name = data[0];
                    string last_name = data[1];
                    DateTime date_of_birth = utility.ParseDateTime(data[2]);
                    string email_address = data[3];
                    string password = data[4].Substring(0, data[4].Length);
                    Address address = utility.ParseAddress(data[5]);
                    if (db.EmailAlreadyInUse(email_address))
                    {
                        string send = $"NACK_INSERT_REGISTRATE:{email_address}";
                        SendMessageToSocket(send, socket);
                    }
                    else
                    {
                        bool success = db.Registrate(first_name, last_name, date_of_birth, email_address, password, address);
                        if (success)
                        {
                            string send = $"ACK_INSERT_REGISTRATE:{email_address}";
                            SendMessageToSocket(send, socket);
                        }
                        else
                        {
                            string send = $"FAIL_INSERT_REGISTRATE:{email_address}";
                            SendMessageToSocket(send, socket);
                        }
                    }
                }
                else if (protocol.StartsWith("REQ_LOGIN"))
                {
                    string username = data[0];
                    string userid = db.RetrieveUserID(username);
                    string password = db.RetrievePassword(username);
                    string send = $"ACK_REQ_LOGIN:{userid}/{username}/{password};";
                    SendMessageToSocket(send, socket);
                }
                else if (protocol.StartsWith("UPDATE_DETAILS"))
                {
                    string[] columns = utility.ValuesStringTrimmer(data[0]);
                    string[] newValues = utility.ValuesStringTrimmer(data[1]);
                    if (db.ChangeUserDetails(columns, newValues))
                    {
                        string send = "";
                        SendMessageToSocket(send, socket);
                    }
                    else
                    {
                        string send = "";
                        SendMessageToSocket(send, socket);
                    }
                }
            }
            else
            {
                Console.WriteLine($"{prefix}Received command for Database-data, but can not reach Database.\nServer is not connected to 'vdi.fhict.nl' via a VPN connection");
            }
        }
        
        private void SendMessageToSocket(string message, Socket socket)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
            Console.WriteLine($"Sent: {message}");
        }
    }
}
