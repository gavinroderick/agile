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
            string user = "99C008";
            string query = "SELECT * FROM 17agileteam6db.history WHERE user = '" + user + "'";
            DBTest db = new DBTest();
            string info = "";
            MySql.Data.MySqlClient.MySqlDataReader reader = db.Select(query);

            while (reader.HasRows && reader.Read())
            {
                info = reader.GetString(reader.GetOrdinal("projectAction"));
            }

            Assert.AreEqual("Upload", info);
        }


        [TestMethod]
        public void TestHistoryUpload()
    {
            DBTest db = new DBTest();
            string user = "99C009";
            string comment = "Uploaded the file";
            int project_ID = 3;
            string action = "Upload";
            string query = "INSERT INTO 17agileteam6db.history (project_ID, user, Historycol, date_time, projectAction, Comments) VALUES (" + project_ID + ", '" + user + "', ' ', NOW(), '" + action + "', '" + comment + "')";

            bool insert = db.Insert(query);
            Assert.AreEqual(true, insert);
        }
}
}
