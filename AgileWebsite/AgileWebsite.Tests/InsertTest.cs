using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class InsertTest
    {
        [TestMethod]
        //checks if insert is working Correctly if given correct values
        public void TestInsertSuccess()
        {
            DBTest db = new DBTest();
            string query = "INSERT INTO 17agileteam6db.users (user_ID, staff_no, first_name, last_name, email, department, role, pass) VALUES(9, '20XO10', 'LiAM', 'Collins', 'l.collins@dundee.ac.uk', 'Engineering', 0, 'guest')";
            bool insert = db.Insert(query);
            Assert.AreEqual(true, insert);
        }
        [TestMethod]
        //Checks if insert fails when given bad values
        public void TestInsertfail()
        {
            DBTest db = new DBTest();
            string query = "INSERT INTO 17agileteam6db.users VALUES (1, 3, 4, 'Engineering', 0, 'guest')";
            Assert.AreEqual(false, db.Insert(query));
        }

    }
}
