using System;
using System.Text;
using System.Configuration;
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
                Console.Write(TDES.Key);
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

        //https://stackoverflow.com/questions/11413576/how-to-implement-triple-des-in-c-sharp-complete-example
        //altered some fo the code from above website to take in a key then encrypt and decrypt
        public static string Encrypt(string toEncrypt, TripleDES tdes)
        {
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            System.Configuration.AppSettingsReader settingsReader =
                                                new AppSettingsReader();
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
