using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class UpdateTest
    {
        [TestMethod]
        //checks if the update method works correctly with correct info.
        public void TestUpdateSuccess()
        {
            DBTest db = new DBTest();
            string query = "UPDATE 17agileteam6db.users SET first_name = 'Dan' WHERE user_ID = 3";
            Assert.AreEqual(true, db.Update(query));
        }
        [TestMethod]
        //checks if the Update method fails with incorrect info
        public void TestUpdateFail()
        {
            DBTest db = new DBTest();
            string query = "UPDATE 17agileteam6db.users SET first_name = 32 WHERE user_ID = 'ew'";
            Assert.AreEqual(false, db.Update(query));
        }
    }
}
