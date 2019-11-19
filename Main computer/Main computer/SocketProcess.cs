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
        private WaitHandle[] waitHandles;
        private Socket listener;
        private CommandHandling handling;
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

        private void ProcessSocketConnection(object threadState)
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
            Database db = new Database();
            CommandHandling handling = new CommandHandling(cleanCommand, socket, db);
            if (cleanCommand.StartsWith("DB"))
            {
                if (db.IsDatabaseReachable())
                {
                    handling.DatabaseCommandsHandler(cleanCommand.Substring(3));
                }
                else
                {
                    Console.WriteLine($"{prefix}Received command for Database-data, but can not reach Database.\nServer is not connected to 'vdi.fhict.nl' via a VPN connection");
                }
            }
            else if (cleanCommand.StartsWith("ARD"))
            {

            }
        }
    }
}
