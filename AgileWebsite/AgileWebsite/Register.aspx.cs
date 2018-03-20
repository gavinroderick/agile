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
        protected void Page_Load(object sender, EventArgs e)
        {
            
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

    }

}