using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class EditProjectPage : Page
    {
            
        protected void Page_Load(object sender, EventArgs e)
        {

        }

     

        public void DownloadExistingFile(string projectName)
        {
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.AddHeader("Content-Disposition", "attachment; filename=pdffile.pdf");
            Response.TransmitFile(Server.MapPath("Projects") + "\\" + "teser1.pdf");
            Response.End();
        }

        
      
    }
}