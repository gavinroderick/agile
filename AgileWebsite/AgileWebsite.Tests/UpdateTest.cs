using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class UpdateTest
    {
        [TestMethod]
        public void TestUpdate()
        {
            DBTest db = new DBTest();
            string query = "UPDATE 17agileteam6db.users SET first_name = 'Dan' WHERE user_ID = 3";
            Assert.AreEqual(true, db.Update(query));
        }
    }
}
