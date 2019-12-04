using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;
using System.Net.Sockets;
using System.Collections.Generic;

namespace Unit_tests_Main_Computer
{
    [TestClass]
    public class Unit_Test_CommandHandling
    {
        [TestMethod]
        public void Test_Constructor()
        {
            Socket socket = null;
            string command = "DB_INSERT_REGISTRATE:FirstName/LastName/01_01_2001/test@test.nl/password/Rachelsmolen_1_0000NN_Eindhoven_Netherlands;";
            CommandHandling handling = new CommandHandling(command, socket);
            string[] expectedData = { "FirstName", "LastName", "01_01_2001", "test@test.nl", "password", "Rachelsmolen_1_0000NN_Eindhoven_Netherlands" };
            Database expectedDatabase = new Database();
            Assert.AreEqual(expectedData[0], handling.Data[0]);
            Assert.AreEqual(expectedData[1], handling.Data[1]);
            Assert.AreEqual(expectedData[2], handling.Data[2]);
            Assert.AreEqual(expectedData[3], handling.Data[3]);
            Assert.AreEqual(expectedData[4], handling.Data[4]);
            Assert.AreEqual(expectedData[5], handling.Data[5]);
            Assert.AreEqual(command, handling.Command);
            Assert.AreEqual(socket, handling.ClientSocket);
            Assert.AreEqual(expectedDatabase, handling.Database);
        }
    }
}
