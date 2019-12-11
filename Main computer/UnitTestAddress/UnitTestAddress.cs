using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;

namespace UnitTestAddress
{
    [TestClass]
    public class UnitTestAddress
    {
        [TestMethod]
        public void TestMethTest_Address_DefaultCunstructorod()
        {
            Address address = new Address("Street", "10", "5555AA", "Eindhoven", "The Netherlands");
            Assert.AreEqual("Street", address.Street);
            Assert.AreEqual("10", address.Number);
            Assert.AreEqual("5555AA", address.Zipcode);
            Assert.AreEqual("Eindhoven", address.City);
            Assert.AreEqual("The Netherlands", address.Country);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMethTest_Address_ExNUll()
        {
            Address address1 = new Address(null, "10", "5555AA", "Eindhoven", "The Netherlands");
            Address address2 = new Address("Street", null, "5555AA", "Eindhoven", "The Netherlands");
            Address address3 = new Address("Street", "10", null, "Eindhoven", "The Netherlands");
            Address address4 = new Address("Street", "10", "5555AA", null, "The Netherlands");
            Address address5 = new Address("Street", "10", "5555AA", "Eindhoven", null);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestMethTest_Address_ExOutOfRange()
        {
            Address address6 = new Address("", "10", "5555AA", "Eindhoven", "The Netherlands");
            Address address7 = new Address("Street", "", "5555AA", "Eindhoven", "The Netherlands");
            Address address8 = new Address("Street", "10", "", "Eindhoven", "The Netherlands");
            Address address9 = new Address("Street", "10", "5555AA", "", "The Netherlands");
            Address address10 = new Address("Street", "10", "5555AA", "Eindhoven", "");
        }

        [TestMethod]
        public void TestMethTest_Address_ToString()
        {
            Address address = new Address("Street", "10", "5555AA", "Eindhoven", "The Netherlands");
            Assert.AreEqual("Street 10, 5555AA, Eindhoven, The Netherlands", address.ToString());

        }


    }
}
