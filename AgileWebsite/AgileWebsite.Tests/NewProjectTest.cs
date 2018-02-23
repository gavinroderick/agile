using System;
using MySql.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AgileWebsite.Tests
{
    [TestClass]
    public class NewProjectTest
    {
        [TestMethod]
        public void TestNewProjectSuccess()
        {
            Assert.AreEqual(true, MyMethod());
        }

        [TestMethod]
        public void TestNewProjectFailed()
        {
            Assert.AreEqual(false, MyMethod());
        }

        public bool MyMethod()
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Projects") + "\\" + fn;
                try
                {
                    File1.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                    return true;
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    return false;
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
                return false;
            }
        }
    }
}
