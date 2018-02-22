using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class FinalCreateNewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query;
            DB db = new DB();
            if (FileUpload1.HasFile)
            try
            {
                string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                string SaveLocation = Server.MapPath("~/Projects/" + fn);


                query = "INSERT INTO files (file_name, date_uploaded) VALUES (" + fn + ", " + DateTime.Now + ", " + FileUpload1.PostedFile + ")";
                string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('scot2', '1111-11-11 20:20')";
                db.Insert(query2);

                //FileUpload1.SaveAs(SaveLocation);

                Label1.Text = "File name: " +
                     FileUpload1.PostedFile.FileName + "<br>" +
                     FileUpload1.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     FileUpload1.PostedFile.ContentType;
            }
            catch (Exception ex)
            {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
            }
            else
            {
                Label1.Text = "You have not specified a file.";
            }
        }
    }
}