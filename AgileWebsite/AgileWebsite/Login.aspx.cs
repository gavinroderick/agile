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
        protected void Page_Load(object sender, EventArgs e)
		{
            
        }
        protected void SubmitEventMethod(object sender, EventArgs e)
        {
            string username = Username.Text;
            string pass = Password.Text;
            query = "SELECT * FROM 17agileteam6db.users WHERE staff_no ='" + username + "' AND pass = '" + pass + "';";
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
                Session["failed"] = "failed";
                Response.Redirect("Login.aspx", false);
            }
            reader.Close();
        }
    }
}