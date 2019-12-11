using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;

namespace Unit_tests_Main_Computer
{
    [TestClass]
    public class UnitTestUser
    {
        [TestMethod]
        public void Test_User_DefaultCunstructor()
        {
            DateTime date = new DateTime(2019, 12, 12);
            Address address = new Address("street", "88", "5555MM", "Eindhoven", "The Neterlands");
            User user = new User("Henk", "Pieterjan", date, "henk@live.nl", "ww", address, 10);
            Assert.AreEqual("Henk", user.FirstName);
            Assert.AreEqual("Pieterjan", user.LastName);
            Assert.AreEqual(date, user.DateOfBirth);
            Assert.AreEqual("henk@live.nl", user.Email);
            Assert.AreEqual("ww", user.Password);
            Assert.AreEqual(address, user.Address);
            Assert.AreEqual(10, user.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Test_User_DefaultCunstructor_Ex()
        {
            DateTime date = new DateTime(2019, 12, 12);
            Address address = new Address("street", "88", "5555MM", "Eindhoven", "The Neterlands");
            User user = new User(null, "Pieterjan", date, "henk@live.nl", "ww", address, 10);
            User user1 = new User("Henk", null, date, "henk@live.nl", "ww", address, 10);
            User user2 = new User("Henk", "Pieterjan", date, "henk@live.nl", null, address, 10);
        }

        [TestMethod]
        public void Test_User_ToString()
        {
            DateTime date = new DateTime(2019, 12, 12);
            Address address = new Address("street", "88", "5555MM", "Eindhoven", "The Neterlands");
            User user = new User("Henk", "Pieterjan", date, "henk@live.nl", "ww", address, 10);
            Assert.AreEqual("Name: Henk Pieterjan \nBirthday: 12-12-2019 \nEmail: henk@live.nl \nBalance: 10", user.ToString());

        }
    }
}
