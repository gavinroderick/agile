using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class SendEmailTest
    {
        //Sends Successful Mail
        [TestMethod]
        public void TestEmailSuccess()
        {
            bool sent = false;
            sent = Email("joshng@hotmail.co.uk", "Hello");
            Assert.AreEqual(true, sent);
        }
        //Sends Failure Mail
        [TestMethod]
        public void TestEmailFail()
        {
            bool sent = Email("ewqeqw", "Hi");
            Assert.AreEqual(false, sent);
        }

        public bool Email(string toEmail, string message)
        {
            try
            {
                MailMessage mail = new MailMessage("team6agile@gmail.com", toEmail);
                SmtpClient client = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("team6agile@gmail.com", "AgileTeam6"),
                    EnableSsl = true

                };
                mail.Subject = "this is a test email.";
                mail.Body = message;
                client.Send(mail);
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}