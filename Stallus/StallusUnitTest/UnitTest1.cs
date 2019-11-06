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
            Customer customer = new Customer("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
            Assert.AreEqual("Hans", customer.FirstName);
            Assert.AreEqual("de Vries", customer.LastName);
            Assert.AreEqual("ww", customer.Password);
            Assert.AreEqual(dateTime, customer.DateOfBirth);
            Assert.AreEqual("hansdv@gmail.com", customer.Email);
            Assert.AreEqual(10, customer.Balance);
            Assert.AreEqual(address, customer.Address);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestSetting_NullValue_InConstructor_Customer()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Customer customer = new Customer(null, null, null, dateTime, null, 0, null);
        }

        [TestMethod]
        public void TestCustomerToStringReturn()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Customer customer = new Customer("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
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
            Customer customer = new Customer("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
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


        [TestMethod]
        public void RecievePasswordOutOfDatabase()
        {
            Database database = new Database("Server = studmysql01.fhict.local; Uid = dbi413213; Database = dbi413213; Pwd = helmond;");
            Assert.AreEqual("stallus", database.StallusLogin("admin"));
            Assert.AreEqual(null, database.StallusLogin("Hoi"));
        }

        [TestMethod]
        public void TestValuesInDatabase()
        {
            DateTime dateTime = new DateTime(2001, 05, 23);
            Address address = new Address("Wega", "9", "5505TL", "Veldhoven");
            Customer customer = new Customer("Hans", "de Vries", "ww", dateTime, "hansdv@gmail.com", 10, address);
            Database database = new Database("Server = studmysql01.fhict.local; Uid = dbi413213; Database = dbi413213; Pwd = helmond;");
            Assert.AreEqual(0, database.StallusRegistrate(customer));
            // When we dont use VPN
            //Assert.AreEqual(-1, database.StallusRegistrate(customer));
        }
    }
}
