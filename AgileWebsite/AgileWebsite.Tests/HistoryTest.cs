using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class HistoryTest
    {
        //Checks if the Correct output from the search string is correct.
        [TestMethod]
        public void SuccessHistory()
        {

            string query = "SELECT * FROM 17agileteam6db.history WHERE user = '99C008'";
            DBTest db = new DBTest();
            string info = "";
            MySql.Data.MySqlClient.MySqlDataReader reader = db.Select(query);

            while (reader.HasRows && reader.Read())
            {
                info = reader.GetString(reader.GetOrdinal("projectAction"));
            }

            System.Diagnostics.Debug.Write(info);
            Assert.AreEqual("Upload", info);
        }

    }
}
