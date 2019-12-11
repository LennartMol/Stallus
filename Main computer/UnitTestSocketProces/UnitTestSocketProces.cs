using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;
using System.Net.Sockets;
using System.Net;

namespace UnitTestSocketProces
{
    [TestClass]
    public class UnitTestSocketProces
    {
        [TestMethod]
        public void Test_SocketProces_DefaultConstructor()
        {
            IPAddress iPAddress = new IPAddress(12916811);
            SocketProcess socketProcess = new SocketProcess(iPAddress,1,2,3,1024);
            Assert.AreEqual(iPAddress, socketProcess.IPAddress);
            Assert.AreEqual(1, socketProcess.Port);
            Assert.AreEqual(2, socketProcess.MaxThreads);
            Assert.AreEqual(3, socketProcess.DataTimeReadout);
            Assert.AreEqual(1024, socketProcess.StorageSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_SocketProces_DefaultConstructor_Ex()
        {
            IPAddress iPAddress = new IPAddress(12916811);
            SocketProcess socketProcess = new SocketProcess(iPAddress, 0, 2, 3, 1024);            
        }

        [TestMethod]
        public void Test_SocketProces_InitializeSocketProcessing()
        {
            IPAddress iPAddress = new IPAddress(12916811);
            SocketProcess socketProcess = new SocketProcess(iPAddress, 1, 2, 3, 1024);
            Socket listener = new Socket(SocketType.Stream, ProtocolType.Tcp);
            socketProcess.InitializeSocketProcessing();
            //Assert.AreEqual(,listener.);
            
        }
    }
}
