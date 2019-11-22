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
            User customer = new User("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
            User customer2 = new User("hansDV@hotmail.com", "HansiePansie123", 0);
            Assert.AreEqual("Hans", customer.FirstName);
            Assert.AreEqual("de Vries", customer.LastName);
            Assert.AreEqual("ww", customer.Password);
            Assert.AreEqual(dateTime, customer.DateOfBirth);
            Assert.AreEqual("hansdv@gmail.com", customer.Email);
            Assert.AreEqual(10, customer.Balance);
            Assert.AreEqual(address, customer.Address);
            Assert.AreEqual("hansDV@hotmail.com", customer2.Email);
            Assert.AreEqual("HansiePansie123", customer2.Password);
            Assert.AreEqual(0, customer2.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSetting_NullValue_InConstructor_Customer()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            User customer = new User(null, null, null, dateTime, null, 0, null);
        }

        [TestMethod]
        public void TestCustomerToStringReturn()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            User customer = new User("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
            string expected = $"Name: Hans de Vries \n" +
                              $"Birthday: {dateTime.ToShortDateString()} \n" +
                              $"Email: hansdv@gmail.com \n" +
                              $"Balance: 10";
            Assert.AreEqual(expected, customer.ToString());
        }


        [TestMethod]
        public void RaiseBallanceOfCustomer()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            User customer = new User("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
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
        public void TestAddressToStringReturn()
        {
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Assert.AreEqual($"Address: Wega 9 \n" +
                            $"5505TL Veldhoven", address.ToString());
        }


    }
}
