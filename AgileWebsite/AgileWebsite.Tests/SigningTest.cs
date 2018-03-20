using System;
using System.Text;
using System.Configuration;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class SigningTest
    {
        [TestMethod]
        //Checks if it Signs Correctly
        public void SignTest()
        {
            string role = "RIS";
            int project_ID = 2;
            DBTest db = new DBTest();
            string query = "UPDATE 17agileteam6db.projects SET "+ role + "_accepted = 1 WHERE project_ID = "+ project_ID;
            
            bool worked = db.Insert(query);
            Assert.AreEqual(worked, true);
        }

        [TestMethod]
        //Checks if the History Works with signing
        public void SignHistoryTest()
        {
            string role = "RIS";
            bool worked;
            int project_ID = 3;
            DBTest db = new DBTest();
            worked = db.History(project_ID, role, "Signed", " ");

            Assert.AreEqual(worked, true);
        }

    }
}
