using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgileWebsite.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using MySql.Data;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AgileWebsite;

    namespace DownloadTests
    {
        [TestClass]
        public class BankAccountTests
        {
            [TestMethod]
            public void TestExistingFileDownload()
            {
                EditProjectPage downloadPage;
                downloadPage = new EditProjectPage();
                Assert.AreEqual(true, downloadPage.Download("Test31"));
            }

            [TestMethod]
            public void TestNonExistingFileDownload()
            {
                EditProjectPage downloadPage;
                downloadPage = new EditProjectPage();
                Assert.AreEqual(true, downloadPage.Download("FalseTest"));
            }
        }
    }
}
