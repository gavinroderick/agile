using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class researcherOptions : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_options_Click(object sender, EventArgs e)
        {
            if (finished.Checked == true)
            {
                Response.Redirect("ViewFinishedProjects.aspx");
            }

            if (create.Checked == true)
            {
                Response.Redirect("FinalCreateNewProject.aspx");
            }
        }
    }
}