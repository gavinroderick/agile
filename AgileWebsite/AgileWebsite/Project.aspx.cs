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
        string projectID;
        int fileID;
        string researcherID;
        string projectInfo;
        string dateSubmitted;
        string projectName;

        protected void Page_Load(object sender, EventArgs e)
        {
            projectID = Request.QueryString["id"];
            if (projectID == null)
            {
                projectID = "21";
            }

            int projID = int.Parse(projectID);

            getProjectDetails(projID);
        }

        private void getProjectDetails(int projectID)
        {
            DB db = new DB();

            string projectQuery = "SELECT * FROM PROJECTS WHERE project_ID =" + projectID;
            db.Select(projectQuery);
        }
    }
}