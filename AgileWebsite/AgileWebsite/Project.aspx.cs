using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class Project : System.Web.UI.Page
    {
        string projectName;
        string projectID;
        protected void Page_Load(object sender, EventArgs e)
        {
            projectID = Request.QueryString["id"];
            if (projectID == null)
            {
                projectID = "21";
            }
            int.Parse(projectID);

        }

        private void getProjectDetails()
        {

        }
    }
}