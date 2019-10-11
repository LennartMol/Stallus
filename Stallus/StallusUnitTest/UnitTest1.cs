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
            Customer customer = new Customer("Hans", dateTime, 1, "hansdv@gmail.com", 10);
            Assert.AreEqual("Hans", customer.Name);
            Assert.AreEqual(dateTime, customer.DateOfBirth);
            Assert.AreEqual(1, customer.CustomerId);
            Assert.AreEqual("hansdv@gmail.com", customer.Email);
            Assert.AreEqual(10, customer.Balance);
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
    }
}
