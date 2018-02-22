using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class ConnectionTest
    {
        [TestMethod]
        public void ConnectionTest()
        {
            DBTest db = new DBTest();
            Assert.AreEqual(true, db.OpenConnection());
        }
    }
}
