using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stallus;

namespace StallusUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Default_Constructor_Customer()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Customer customer = new Customer("Hans", "ww", dateTime, "hansdv@gmail.com", 10, address);
            Assert.AreEqual("Hans", customer.Name);
            Assert.AreEqual(dateTime, customer.DateOfBirth);
            Assert.AreEqual("hansdv@gmail.com", customer.Email);
            Assert.AreEqual(10, customer.Balance);
        }

        [TestMethod]
        public void RaiseBallanceOfCustomer()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Customer customer = new Customer("Hans", "ww", dateTime, "hansdv@gmail.com", 10, address);
            Assert.AreEqual(20, customer.RaiseBalance(10));
            Assert.AreEqual(20, customer.RaiseBalance(-10));
        }


        [TestMethod]
        public void Default_Constructor_Address()
        {
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Assert.AreEqual("Wega", address.Street);
            Assert.AreEqual("9", address.Number);
            Assert.AreEqual("5505TL", address.Zipcode);
            Assert.AreEqual("Veldhoven", address.City);
        }

        [TestMethod]
        public void RecievePasswordOutOfDatabase()
        {
            Database database = new Database("Server = studmysql01.fhict.local; Uid = dbi413213; Database = dbi413213; Pwd = helmond;");
            Assert.AreEqual("stallus", database.StallusLogin("admin"));
            Assert.AreEqual(null, database.StallusLogin("Hoi"));
        }
    }
}
