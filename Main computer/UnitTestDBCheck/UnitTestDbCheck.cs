using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;
using MySql.Data.MySqlClient;

namespace UnitTestDBCheck
{
    [TestClass]
    public class UnitTestDbCheck
    {
        /*[TestMethod]
        public void TestMethTest_DbCheck_DefaultCunstructorod_WhithMySQLEx()
        {
            MySqlException mySqlException;
            DbCheck dbCheck = new DbCheck(true, mySqlException);
            Assert.AreEqual(true,);
        }*/

        [TestMethod]
        public void TestMethTest_DbCheck_DefaultCunstructorod()
        {
            DbCheck dbCheck1 = new DbCheck(true);
            DbCheck dbCheck2 = new DbCheck(false);
            Assert.AreEqual(true, dbCheck1.Reachable);
            Assert.AreEqual(false, dbCheck2.Reachable);
        }
    }
}
