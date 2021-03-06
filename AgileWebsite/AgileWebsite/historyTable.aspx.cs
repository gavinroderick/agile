﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text;
using System.Configuration;
using System.Data.SqlClient;

namespace AgileWebsite
{
    public partial class historyTable : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             //CHECK FOR LOGIN
            string LI = (string)(Session["loggedin"]);
            if (LI != "Loggedin")
            {
                Response.Redirect("Index.aspx", false);
            }

        }

        public string getWhileLoopData()
        {
            //Connect to databse
            DB db = new DB();
            string htmlStr = "";
            //db.GetConnectionStringForScott();
            MySqlConnection thisConnection = db.GetConnectionStringForScott();
            MySqlCommand thisCommand = thisConnection.CreateCommand();
            //Stablish what we want to see in the table
            thisCommand.CommandText = "SELECT * FROM history ";
            thisConnection.Open();
            MySqlDataReader reader = thisCommand.ExecuteReader();
            //Reading process (from the SQL table)
            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string project_ID = reader.GetString(1);
                string user = reader.GetString(2);
                string date_time = reader.GetString(3);
                string projectAction = reader.GetString(4);
                string comments = reader.GetString(5);

                htmlStr += "<tr><td>" + id + "</td><td>" + project_ID + "</td><td>" + user + "</td><td>" + date_time + "</td><td>" + projectAction + "</td><td>" + comments + "</td></tr>";
            }

            thisConnection.Close();
            return htmlStr;
        }
    }
}
