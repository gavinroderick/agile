using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//This page allows RIS to select what they want to do


namespace AgileWebsite
{
    public partial class risOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_options_Click(object sender, EventArgs e)
        {
            if (all.Checked == true)
            {
                Response.Redirect("ris.aspx");
            }

            if (finished.Checked == true)
            {
                Response.Redirect("ViewFinishedProjects.aspx");
}
        }
        
    }
}