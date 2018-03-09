using System;
using MySql.Data;
using System.Security.Cryptography;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class EncryptionKeyTest
    {
        //Created Symmertric Key and inserts it into Signature variable.
        [TestMethod]
        public void CreateKeyTest()
        {
            bool insert = false;
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            try
            {
                TDES.GenerateIV();
                TDES.GenerateKey();
                Console.Write(TDES.Key);
                DBTest db = new DBTest();
                string query = "INSERT INTO 17agileteam6db.signatures (Signature) VALUES('" + TDES.Key + "')";
                insert = db.Insert(query);
            }
            catch
            {

            }
            finally
            {
                Assert.AreEqual(true, insert);
            }

        }

}
}
