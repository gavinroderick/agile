using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class NewProject : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Basic validation
            string MethodName = String.IsNullOrEmpty(Request.QueryString["MethodName"]) ? string.Empty : Request.QueryString["MethodName"];
            SimpleMethodFactory(MethodName);
        }

        protected void SimpleMethodFactory(string MethodName)
        {
            switch (MethodName)
            {
                case "MyMethod":
                    //MyMethod();
                    break;
                default:
                    //print cheese  
                    break;
            }
        }

        

        public void MyMethod()
        {
            if ((File1.PostedFile != null) && (File1.PostedFile.ContentLength > 0))
            {
                string fn = System.IO.Path.GetFileName(File1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("Projects") + "\\" + fn;
                try
                {
                    File1.PostedFile.SaveAs(SaveLocation);
                    Response.Write("The file has been uploaded.");
                }
                catch (Exception ex)
                {
                    Response.Write("Error: " + ex.Message);
                    //Note: Exception.Message returns a detailed message that describes the current exception. 
                    //For security reasons, we do not recommend that you return Exception.Message to end users in 
                    //production environments. It would be better to put a generic error message. 
                }
            }
            else
            {
                Response.Write("Please select a file to upload.");
            }
        }
    }
}