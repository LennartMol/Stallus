﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;

namespace Stallus_1
{
    public class SerialProcess
    {
        private SerialMessenger serialMessenger;
        public bool ReceivedFirstContact { get; private set; }
        public string Portname { get; private set; }
        public SerialProcess(char beginMarker, char endMarker)
        {
            MessageBuilder messageBuilder = new MessageBuilder(beginMarker, endMarker);
            string[] portnames = SerialPort.GetPortNames();
            Portname = portnames[0];
            serialMessenger = new SerialMessenger(Portname, 9600, messageBuilder); //COM3 COM5
        }
        public void InitializeSerialProcessing()
        {
            serialMessenger.Connect();
            Console.WriteLine("<SerialProcess>Waiting for Serial communication on: " + Portname);
            while (true)
            {
                string[] messages = serialMessenger.ReadMessages();
                if (messages != null)
                {
                    foreach (string message in messages)
                    {
                        Console.WriteLine("<SerialProcess>" + message);
                    }
                }
            }
            //try
            //{
                
            //    //while (ReceivedFirstContact == false)
            //    //{
            //    //    if (LookingForFirstContact() == true)
            //    //    {
            //    //        Console.WriteLine("<SerialProcess>Received First Contact message from Arduino module.");
            //    //    }
            //    //}
                
            //}
            //catch (Exception x)
            //{
            //    Console.WriteLine("<ErrorControl>" + x.Message);
            //}
        }
        public bool LookingForFirstContact()
        {
            foreach (string message in serialMessenger.ReadMessages())
            {
                if (message == "CONNECT")
                {
                    ReceivedFirstContact = true;
                    return true;
                }
            }
            return false;
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
