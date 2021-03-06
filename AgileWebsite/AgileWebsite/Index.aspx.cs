﻿using MySql.Data.MySqlClient;
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
                //Session["FirstName"] = reader.GetString("first_name");
                //Session["LastName"] = reader.GetString("last_name");
                //Session["department"] = reader.GetString("department");
                Redirect(getDetails(db, staffID));
            }
            else
            {
                Response.Redirect("Default.aspx", false);
            }
        }

        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT first_name, last_name, department, role from 17agileteam6db.users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        //Redirects to approprate homepage
        private void Redirect(string role)
        {
            switch (role)
            {
                case "0":
                    Response.Redirect("researcher.aspx");
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