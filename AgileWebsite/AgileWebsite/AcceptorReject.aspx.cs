using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class AcceptorReject : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AcceptProject(object sender, EventArgs e)
        {
            string query = "";
            if (Session["role"].Equals("1"))
            {
                query = "UPDATE 17agileteam6db.projects SET RIS_accepted = 'Accepted', RIS_ID = 1 WHERE project_ID = 1"; 
            }
            else if (Session["role"].Equals("2"))
            {
                query = "UPDATE 17agileteam6db.projects SET ass_dean_accepted = 'Accepted', ass_dean_ID = 2 WHERE project_ID = 1";
            }
            else if (Session["role"].Equals("3"))
            {
                query = "UPDATE 17agileteam6db.projects SET dean_accepted = 'Accepted', dean_ID = 3 WHERE project_ID = 1";
            }
            updateProject(query);
        }

        protected void RejectProject(object sender, EventArgs e)
        {
            string query = "";
            if (Session["role"].Equals("1"))
            {
                query = "UPDATE 17agileteam6db.projects SET RIS_accepted = 'Accepted', RIS_ID = 1 WHERE project_ID = 1";
            }
            else if (Session["role"].Equals("2"))
            {
                query = "UPDATE 17agileteam6db.projects SET ass_dean_accepted = 'Accepted', ass_dean_ID = 2 WHERE project_ID = 1";
            }
            else if (Session["role"].Equals("3"))
            {
                query = "UPDATE 17agileteam6db.projects SET dean_accepted = 'Accepted', dean_ID = 3 WHERE project_ID = 1";
            }
            updateProject(query);
        }

        void updateProject(string query)
        {
            DB db = new DB();
            db.Update(query);
        }

    }
}