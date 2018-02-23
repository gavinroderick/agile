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

        public bool Download(string fileName)
        {
            if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName)))
            {
                Response.ContentType = "Application/.xlsx";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                //REFACTORED CODE
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
                // Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
                Response.TransmitFile(Server.MapPath("~/Projects/" + fileName));
                Response.Write("This file exists.");
                Response.End();
                return true;
            }
            else
            {
                Response.Write("This file doesnt exist.");
                return false;
            }
        }
    }
}