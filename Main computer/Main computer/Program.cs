using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Main_computer
{
    class Program
    {

        static void Main(string[] args)
        {
            /*
            // App naar server communicatie
            Socket_server server = new Socket_server();
            server.startServer(); // Use multithreading to simultaneously listen for a client on another thread.
            */

            // Arduino naar server communicatie
            string[] portnames = SerialPort.GetPortNames();
            string portname = portnames[0]; // Get first portname (edit this is if multiple ports are used).
            SerialMessenger serialmessenger = new SerialMessenger(portname, 9600, new MessageBuilder('%'));
            serialmessenger.Connect();

            while (true)
            {
                /*
                // Receive message from app
                Console.WriteLine(server.receiveMessage());
                */

                // Receive message from Arduino
                string[] messages = serialmessenger.ReadMessages();
                if (messages != null)
                {
                    foreach (var message in messages)
                    {
                        Console.WriteLine(message);
                    }
                }
            }
        }
    }
}
