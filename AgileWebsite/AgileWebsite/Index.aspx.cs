using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        MySqlDataReader reader;
        protected void Page_Load(object sender, EventArgs e)
        {
            DB db = new DB();
            string LI = (string)(Session["loggedin"]);
            string staffID;

            if (LI == "Loggedin")
            {
                staffID = (string)(Session["StaffNo"]);
                Redirect(getDetails(db, staffID));
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT role from users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        private void Redirect(string role)
        {
            switch (role)
            {
                case "0":
                    Response.Redirect("FinalCreateNewProject.aspx");
                    break;
                case "1":
                    Response.Redirect("ris.aspx");
                    break;
                case "2":
                    Response.Redirect("assistantdean.aspx");
                    break;
                case "3":
                    Response.Redirect("dean.aspx");
                    break;
            }
                
            
            
        }
    }
}