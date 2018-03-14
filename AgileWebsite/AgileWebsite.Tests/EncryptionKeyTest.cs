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
    public class EncryptionKeyTest
    {
        //Created Symmertric Key and inserts it into Signature variable.
        [TestMethod]
        public void CreateKeyTest()
        {
            bool insert = false;
            MySqlConnection connection;
            MySqlCommand command;
            string server = "silva.computing.dundee.ac.uk";
            string database = "17agileteam6db";
            string uid = "17agileteam6";
            string password = "7845.at6.5487";

            string connString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            connection = new MySqlConnection(connString);

            
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            try
            {
                TDES.GenerateIV();
                TDES.GenerateKey();
                Console.Write(TDES.Key);
                DBTest db = new DBTest();
                string query = "INSERT INTO 17agileteam6db.signatures (Signature) VALUES (@binKey)";
                try
                {
                    connection.Open();
                    command = new MySqlCommand(query, connection);
                    command.Parameters.Add("@binKey", MySqlDbType.VarBinary, 25).Value = TDES.Key;
                    command.ExecuteNonQuery();
                    insert =  true;
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                    insert =  false;
                }
            }
            catch
            {

            }
            finally
            {
                Assert.AreEqual(true, insert);
            }

        }

        //Created Symmertric Key and inserts it into Signature variable.
        [TestMethod]
        public void EncryptionTest()
        {
            TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
            string decrypt = " ";
            string encrypted = " ";
            try
            {
                TDES.GenerateIV();
                TDES.GenerateKey();
                encrypted = Encrypt("Hello", TDES);
                decrypt = Decrypt(encrypted, TDES);
                Assert.AreEqual("Hello", decrypt);
            }
            catch
            {

            }
            finally
            {
               
            }

        }

        [TestMethod]
        public void GetKeyTest()
        {
            
            string query = "SELECT * FROM 17agileteam6db.signatures WHERE idSignatures = 4 ";
            DBTest db = new DBTest();
            MySql.Data.MySqlClient.MySqlDataReader reader = db.Select(query);
            bool match = false;
            byte[] rawData;

            while (reader.HasRows && reader.Read())
            {
                TripleDESCryptoServiceProvider TDES = new TripleDESCryptoServiceProvider();
                rawData = new byte[24];
                rawData = (byte[])reader["Signature"];
                TDES.Key = rawData;
                string encString1 = Encrypt("Hi", TDES);
                string encString2 = Decrypt(encString1, TDES);
                
                if(encString2 == "Hi")
                {
                    match = true;
                }
                Assert.AreEqual(match, true);

            }

            reader.Close();
        }

        //https://stackoverflow.com/questions/11413576/how-to-implement-triple-des-in-c-sharp-complete-example
        //altered some fo the code from above website to take in a key then encrypt and decrypt
        public static string Encrypt(string toEncrypt, TripleDES tdes)
        {
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            // Get the key from config file
      
            //set the secret key for the tripleDES algorithm
            //mode of operation. there are other 4 modes.
            //We choose ECB(Electronic code Book)
            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)

            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            //transform the specified region of bytes array to resultArray
            byte[] resultArray =
              cTransform.TransformFinalBlock(toEncryptArray, 0,
              toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor
            tdes.Clear();
            //Return the encrypted data into unreadable string format
            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }


        public static string Decrypt(string cipherString, TripleDES tdes)
        {
            //get the byte code of the string

            byte[] toEncryptArray = Convert.FromBase64String(cipherString);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();

            //mode of operation. there are other 4 modes. 
            //We choose ECB(Electronic code Book)

            tdes.Mode = CipherMode.ECB;
            //padding mode(if any extra byte added)
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(
                                 toEncryptArray, 0, toEncryptArray.Length);
            //Release resources held by TripleDes Encryptor                
            tdes.Clear();
            //return the Clear decrypted TEXT
            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        
    }
}
