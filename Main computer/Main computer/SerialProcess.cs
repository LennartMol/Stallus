using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Main_computer
{
    public class SerialProcess
    {
        private SerialMessenger serialMessenger;
        public bool ReceivedFirstContact { get; private set; }
        public string Portname { get; private set; }
        private string prefix = "<SerialProcess>";
        public bool PortWasDisconnected { get; private set; }
        public SerialProcess(char beginMarker, char endMarker, string portname)
        {
            MessageBuilder messageBuilder = new MessageBuilder(beginMarker, endMarker);
            Portname = portname;
            serialMessenger = new SerialMessenger(Portname, 9600, messageBuilder); //COM3 COM5
        }
        public void InitializeSerialProcessing()
        {
            serialMessenger.Connect();
            Console.WriteLine($"{prefix}Waiting for Serial communication on: {Portname}");
            while (true)
            {
                string[] messages = serialMessenger.ReadMessages();
                if (messages != null)
                {
                    foreach (string message in messages)
                    {
                        Console.WriteLine(prefix + message);
                    }
                }
                else if (serialMessenger.IsDisconnected)
                {
                    Console.WriteLine($"{prefix}Port: {Portname} was disconnected.");
                }
            }
        }
        private bool IsConnected()
        {
            return serialMessenger.IsConnected();
        }
        private string[] GetMessages()
        {
            return serialMessenger.ReadMessages();
        }
        private void Send(string content)
        {
            serialMessenger.SendMessage(content);
        }
        private void MessageHandler(string message)
        {

        }
    }
}
