using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace AgileWebsite
{
	public partial class Login : System.Web.UI.Page
	{
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string query;
        //When Page is loaded
        protected void Page_Load(object sender, EventArgs e)
		{
            string LI = (string)(Session["loggedin"]); //gets Loggin
            if (LI == "Loggedin") //Checks if user is logged on redirects to page.
            {
                DB db = new DB();
                string staffID = (string)(Session["StaffNo"]);

                Redirect(getDetails(db, staffID)); 
            }
        }
        //When Login has been Pressed
        protected void SubmitEventMethod(object sender, EventArgs e)
        {
            string username = Username.Text;
            string pass = Password.Text;
            query = "SELECT * FROM 17agileteam6db.users WHERE staff_no ='" + username + "' AND pass = '" + pass + "';"; //checks user name and password
            DB db = new DB();

            reader = db.Select(query);
            
            while (reader.HasRows && reader.Read())
            {
                Session["role"] = reader.GetString(reader.GetOrdinal("role"));
                Session["firstName"] = reader.GetString(reader.GetOrdinal("first_name"));
                Session["lastName"] = reader.GetString(reader.GetOrdinal("last_name"));
            }

            if (reader.HasRows)
            {
                Session["loggedin"] = "Loggedin";
                Session["StaffNo"] = Username.Text;
                Response.BufferOutput = true;
                Response.Redirect("Index.aspx", false);
            }
            else
            {
                //If username and password not found return false
                Session["failed"] = "failed";
                Response.Redirect("Login.aspx", false);
            }
            reader.Close();
        }

        //Gets Users Details
        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT first_name, last_name, department, role from 17agileteam6db.users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        //Redirects user to appropriate site
        private void Redirect(string role)
        {
            switch (role)
            {
                case "0":
                    Response.Redirect("Researcher.aspx"); //sends to Researcher
                    break;
                case "1":
                    Response.Redirect("ris.aspx"); //sends to RIS
                    break;
                case "2":
                    Response.Redirect("ass_dean.aspx");//sends to assistant Dean
                    break;
                case "3":
                    Response.Redirect("dean.aspx");//sends to Dean.
                    break;
                default:
                    Response.Redirect("Default.aspx");
                    break;
            }
        }
    }
}