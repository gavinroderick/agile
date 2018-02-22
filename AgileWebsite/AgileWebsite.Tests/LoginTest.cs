using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class ULoginTest
    {
        [TestMethod]
        public void SuccessLogin()
        {
            string username = "99C009";
            string password = "guest";
            string query = "SELECT * FROM 17agileteam6db.users WHERE staff_no ='" + username + "' AND pass = '" + password + "'";
            DBTest db = new DBTest();
            bool login = false;
            MySql.Data.MySqlClient.MySqlDataReader reader = db.Select(query);

            while (reader.HasRows && reader.Read())
            {
                string info = reader.GetString(reader.GetOrdinal("role"));
            }

            if (reader.HasRows)
            {
                login = true;
            }
            else
            {
                login = false;
            }
            reader.Close();
            Assert.AreEqual(true, login);
        }
        [TestMethod]
        public void FailedLogin()
        {
            string username = "321321";
            string password = "guest";
            string query = "SELECT * FROM 17agileteam6db.users WHERE staff_no ='" + username + "' AND pass = '" + password + "'";
            DBTest db = new DBTest();
            bool login = false;
            MySql.Data.MySqlClient.MySqlDataReader reader = db.Select(query);

            while (reader.HasRows && reader.Read())
            {
                string info = reader.GetString(reader.GetOrdinal("role"));
            }

            if (reader.HasRows)
            {
                login = true;
            }
            else
            {
                login = false;
            }
            reader.Close();
            Assert.AreEqual(false, login);
        }

    }
}
