using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class Register : System.Web.UI.Page
    {
        MySqlDataReader reader;

        protected void Page_Load(object sender, EventArgs e)
        {
            //CHECK FOR LOGIN
            string LI = (string)(Session["loggedin"]);
            if (LI == "Loggedin")
            {
                DB db = new DB();
                string staffID = (string)(Session["StaffNo"]);

                Redirect(getDetails(db, staffID));
            }
        }
        protected void Accepted(object sender, EventArgs e)
        {
            string sn = staffNo.Text;
            string fn = firstName.Text;
            string ln = surname.Text;
            string email = emailAddress.Text;
            string dept = department.Text;
            string pass = password.Text;
            string r = role.SelectedItem.Value;
            int.Parse(r);

            DB db = new DB();

            string query = "INSERT INTO 17agileteam6db.users(staff_no, first_name, last_name, email, department, role, pass) " +
                           "VALUES('" + sn + "'," + "'" + fn + "'," + "'" + ln + "'," + "'" + email + "'," + "'" + dept + "'," + r + "," + "'" + pass + "');";

            db.Insert(query);
            Response.Redirect("Login.aspx");
        }

        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT first_name, last_name, department, role from 17agileteam6db.users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        private void Redirect(string role)
        {
            switch (role)
            {
                case "0":
                    Response.Redirect("Researcher.aspx");
                    break;
                case "1":
                    Response.Redirect("ris.aspx");
                    break;
                case "2":
                    Response.Redirect("ass_dean.aspx");
                    break;
                case "3":
                    Response.Redirect("dean.aspx");
                    break;
                default:
                    Response.Redirect("Default.aspx");
                    break;
            }
        }

    }

}