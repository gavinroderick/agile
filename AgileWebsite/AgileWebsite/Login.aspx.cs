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
        MySql.Data.MySqlClient.MySqlConnection conn;
        MySql.Data.MySqlClient.MySqlCommand cmd;
        MySql.Data.MySqlClient.MySqlDataReader reader;
        string query;
        protected void Page_Load(object sender, EventArgs e)
		{
            
        }
        protected void SubmitEventMethod(object sender, EventArgs e)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["webAppConnString"].ToString();
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
            query = "SELECT * FROM 17agileteam6db.users WHERE staff_no ='" + Username.Text + "' AND pass = '" + Password.Text + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(query, conn);
            
            reader = cmd.ExecuteReader();
            
            while (reader.HasRows && reader.Read())
            {
                Session["role"] = reader.GetString(reader.GetOrdinal("role"));
            }

            if (reader.HasRows)
            {
                Session["loggedin"] = "Loggedin";
                Session["StaffNo"] = Username.Text;
                Response.BufferOutput = true;
                Response.Redirect("LoginTest.aspx", false);
            }
            else
            {
                Response.Redirect("failedLogin.aspx", false);
            }
            reader.Close();
            conn.Close();
        }
    }
}