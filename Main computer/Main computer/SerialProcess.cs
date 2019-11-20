using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.Net.Sockets;

namespace Main_computer
{
    public class SerialProcess
    {
        private SerialMessenger serialMessenger;
        private string portname;
        private string prefix = "<SerialProcess>";
        public SerialProcess(char beginMarker, char endMarker, string portname)
        {
            MessageBuilder messageBuilder = new MessageBuilder(beginMarker, endMarker);
            this.portname = portname;
            serialMessenger = new SerialMessenger(portname, 9600, messageBuilder);
        }

        public void InitializeSerialProcessing()
        {
            serialMessenger.Connect();
            Console.WriteLine($"{prefix}Waiting for Serial communication on: {portname}");
            while (true)
            {
                string[] messages = serialMessenger.ReadMessages();
                if (messages != null)
                {
                    foreach (string message in messages)
                    {
                        Console.WriteLine(prefix + message);
                        CommandHandling handling = new CommandHandling(message, serialMessenger);
                        if (message.StartsWith("DB"))
                        {
                            handling.ArduinoCommandsHandler(message.Substring(3));
                        }
                    }
                }
                else if (serialMessenger.IsDisconnected)
                {
                    Console.WriteLine($"{prefix}Port: {portname} was disconnected.");
                }
            }
        }
    }
}
