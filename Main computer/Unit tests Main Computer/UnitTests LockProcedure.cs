using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Main_computer;

namespace Unit_tests_Main_Computer
{
    [TestClass]
    public class UnitTestLockProcedrue
    {
        [TestMethod]
        public void TestMethTest_LockProcedure_DefaultCunstructorod()
        {
            LockProcedure lockProcedure1 = new LockProcedure("1", LockProcedure.StartingWith.StandID);
            LockProcedure lockProcedure2 = new LockProcedure("2", LockProcedure.StartingWith.UserID);

            Assert.AreEqual("1", lockProcedure1.StandID);
            Assert.AreEqual("2", lockProcedure2.UserID);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestMethTest_LockProcedure_ExNUll()
        {
            LockProcedure lockProcedure1 = new LockProcedure(null, LockProcedure.StartingWith.StandID);
        }

        [TestMethod]
        public void TestMethTest_LockProcedure_ToString()
        {
            LockProcedure lockProcedure1 = new LockProcedure("1", LockProcedure.StartingWith.StandID);
            LockProcedure lockProcedure2 = new LockProcedure("2", LockProcedure.StartingWith.UserID);

            Assert.AreEqual("1/", lockProcedure1.ToString());
            Assert.AreEqual("/2", lockProcedure2.ToString());

        }

    }
}
