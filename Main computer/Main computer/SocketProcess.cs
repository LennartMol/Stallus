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
        public int Port { get; private set; }
        public int MaxThreads { get; private set; }
        public int DataTimeReadout { get; private set; }
        public int StorageSize { get; private set; }
        public SocketProcess(int port, int maxThreads, int dataTimeReadout, int storageSize)
        {
            if (port < 1)
            {
                throw new ArgumentException("Port cannot be zero", "port");
            }
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
            listener.Bind(new IPEndPoint(IPAddress.Parse("145.93.73.21"), Port)); //GetIPAddress() // IPAddress.Parse("145.93.73.139")
            listener.Listen(25);

            while (true)
            {
                Console.WriteLine("<SocketProcess>Waiting for a TCP connection");
                Socket sock = listener.Accept();

                Console.WriteLine("<SocketProcess>Got a connection");
                Console.WriteLine("<SocketProcess>Waiting for idle thread");
                int index = WaitHandle.WaitAny(waitHandles);

                Console.WriteLine("<SocketProcess>Starting new thread to process client");

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

        public void ProcessSocketConnection(object threadState)
        {
            ThreadParams state = (ThreadParams)threadState;
            Console.WriteLine($"<SocketProcess>Thread {state.ThreadIndex} is processing connection"); //{state.ClientSocket.RemoteEndPoint}

            // This should be an extra method. In general this code should be more modular!
            byte[] recievBuffer = new byte[StorageSize];
            if (state.ClientSocket.Poll(DataTimeReadout, SelectMode.SelectRead))
            {
                state.ClientSocket.Receive(recievBuffer);
            }
            else
            {
                Console.WriteLine("<SocketProcess>Got no data, aborting");
                Cleanup();
            }
            // Do your data Processing in this Method.
            DoWork(recievBuffer, state.ClientSocket);
            Cleanup();
            // This is a local Function introduced in c#7
            void Cleanup()
            {
                Console.WriteLine("<SocketProcess>Doing clean up tasks");
                state.ClientSocket.Shutdown(SocketShutdown.Both);
                state.ClientSocket.Close();
                state.ClientSocket.Dispose();

                recievBuffer = new byte[StorageSize];

                state.ThreadHandle.Set();
            }
        }
        private  void DoWork(byte[] context, Socket socket)
        {
            string command = Encoding.ASCII.GetString(context);
            if (command.StartsWith("INSERT_DB_"))
            {
                DatabaseCommandsHandler(command);
            }
        }

        private string[] CommandStringTrimmer(string stringToTrim)
        {
            string cleanString = stringToTrim.Substring(stringToTrim.IndexOf(';'));
            string[] returnArray = cleanString.Split('/');
            return returnArray;
        }

        private void DatabaseCommandsHandler(string command)
        {
            Database db = new Database();
            if (command.Substring(9).StartsWith("REGISTRATE"))
            {
                string[] data = CommandStringTrimmer(command);
                db.Registrate(data[0], data[1], new DateTime(data[2])); ;  //year month day
            }
        }
    }
}
