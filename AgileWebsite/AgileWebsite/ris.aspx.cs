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
        private MySqlDataReader reader;
        private string query;
        public string firstName;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            DB database = new DB();
            query = "SELECT * FROM users;";
            reader = database.Select(query);
            if (reader.HasRows)
            {
                reader.Read();
                firstName = (reader.GetString("first_name"));
            }
        }
    }
}