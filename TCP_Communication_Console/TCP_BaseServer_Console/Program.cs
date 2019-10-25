using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace TCP_BaseServer_Console
{
    internal class Program
    {
        private const int port = 13000;
        private const int maxThreads = 4;
        private const int dataTimeReadout = 5_000_000;
        private const int storageSize = 1024 * 256;

        private static WaitHandle[] waitHandles;
        private static Socket listener;

        private struct ThreadParams
        {
            public AutoResetEvent ThreadHandle;
            public Socket ClientSocket;
            public int ThreadIndex;
        }

        private static void Main(string[] args)
        {
            Console.WriteLine("Hello world, I'm the Server. Currently listening on " + "145.93.73.139" + ":" + port); //GetIPAddress()
            waitHandles = new WaitHandle[maxThreads];
            for (int i = 0; i < maxThreads; ++i)
            {
                waitHandles[i] = new AutoResetEvent(true);
            }

            listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            listener.Bind(new IPEndPoint(IPAddress.Parse("145.93.73.139"), port)); //GetIPAddress()
            listener.Listen(25); 

            while (true)
            {
                Console.WriteLine("Waiting for a connection");
                Socket sock = listener.Accept();

                Console.WriteLine("Got a connection");
                Console.WriteLine("Waiting for idle thread");
                int index = WaitHandle.WaitAny(waitHandles);

                Console.WriteLine("Starting new thread to process client");

                ThreadParams context = new ThreadParams()
                {
                    ThreadHandle = (AutoResetEvent)waitHandles[index],
                    ClientSocket = sock,
                    ThreadIndex = index
                };

                ThreadPool.QueueUserWorkItem(ProcessSocketConnection, context);
            }
        }
        private static IPAddress GetIPAddress()
        {
            IPHostEntry hostEntry = Dns.GetHostEntry(Environment.MachineName);
            foreach (IPAddress address in hostEntry.AddressList)
            {
                if (address.AddressFamily == AddressFamily.InterNetwork)
                    return address;
            }
            return null;
        }

        private static void ProcessSocketConnection(object threadState)
        {
            ThreadParams state = (ThreadParams)threadState;
            Console.WriteLine($"Thread {state.ThreadIndex} is processing connection{state.ClientSocket.RemoteEndPoint}");

            // This should be an extra method. In general this code should be more modular!
            byte[] recievBuffer = new byte[storageSize];
            if (state.ClientSocket.Poll(dataTimeReadout, SelectMode.SelectRead))
            {
                state.ClientSocket.Receive(recievBuffer);
            }
            else
            {
                Console.WriteLine("Got no data, aborting");
                Cleanup();
            }
            // Do your data Processing in this Method.
            DoWork(recievBuffer, state.ClientSocket);

            // This is a local Function introduced in c#7
            void Cleanup()
            {
                Console.WriteLine("Doing clean up tasks");
                state.ClientSocket.Shutdown(SocketShutdown.Both);
                state.ClientSocket.Close();
                state.ClientSocket.Dispose();

                recievBuffer = new byte[storageSize];

                state.ThreadHandle.Set();
            }
        }

        private static void DoWork(byte[] context, Socket socket)
        {
            bool sent = false;
            Console.WriteLine("Doing 5 seconds worth of work on data");
            DateTime futureTime = DateTime.Now.AddSeconds(5);
            while (DateTime.Now < futureTime)
            {
                if (sent == false)
                {
                    string contextString = Encoding.ASCII.GetString(context);
                    switch (contextString.Substring(0, 1))
                    {
                        case "!":
                            Console.WriteLine("Received: {0}", contextString);
                            string toReturn = contextString.Substring(1);
                            Console.WriteLine("Processing: {0}", toReturn);
                            toReturn = toReturn.ToUpper();
                            byte[] msg = Encoding.ASCII.GetBytes(toReturn);
                            socket.Send(msg);
                            Console.WriteLine("Sent: {0}", toReturn);
                            sent = true;
                            break; 
                    }
                }
            }
        }
    }
}
