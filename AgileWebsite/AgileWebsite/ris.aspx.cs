﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class ris_home : System.Web.UI.Page
    {
        MySqlDataReader reader;
        public String[] data = new String[1];
        public String[] projectID = new String[1];
        public String[] projectName = new string[1];
        public String[] fileName = new String[1];
        public String[] firstName = new String[1];
        public String[] lastName = new String[1];
        public String[] department = new String[1];
        public String[] risDenied = new String[1];
        public String[] risID = new String[1];
        protected void Page_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
            String query = "SELECT project_ID, project_name, files.file_name, users.first_name, users.last_name, users.department, RIS_ID  FROM PROJECTS  JOIN users ON researcher_ID = users.staff_no  JOIN files ON projects.file_ID = files.file_ID WHERE RIS_accepted = 0 OR RIS_accepted is NULL";
            //String query = "SELECT project_ID, project_name, files.file_name, users.first_name, users.last_name, users.department, RIS_denied, RIS_ID  FROM PROJECTS  JOIN users ON researcher_ID = users.staff_no  JOIN files ON projects.file_ID = files.file_ID WHERE (RIS_accepted = 0 OR RIS_accepted is NULL)";

            //CHECK FOR LOGIN
            string LI = (string)(Session["loggedin"]);
            if (LI != "Loggedin")
            {          
                Response.Redirect("Index.aspx", false);
            }
            else  //CHECK & ENSURE USER IS RESEARCHER
            {
                DB db = new DB();
                string staffID = (string)(Session["StaffNo"]);

                Redirect(getDetails(db, staffID));
            }

            int i = 0;

            try
            {
                reader = dB.Select(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int n = 0; n < 7; n++)
                        {
                            data[i] += reader.GetString(n) + ',';
                        }



                        i++;

                        Array.Resize<String>(ref data, i + 1);

                    }
                }
            }
            catch
            {
                // nothing
            }

            // String info = new String[][];

            for (int j = 0; j < i; j++)
            {
                System.Diagnostics.Debug.WriteLine("++++++++++++++++++++++++++++++++++");
                //System.Diagnostics.Debug.WriteLine(data[j]);

                Array.Resize<String>(ref projectID, j + 1);
                Array.Resize<String>(ref projectName, j + 1);
                Array.Resize<String>(ref fileName, j + 1);
                Array.Resize<String>(ref firstName, j + 1);
                Array.Resize<String>(ref lastName, j + 1);
                Array.Resize<String>(ref department, j + 1);
                Array.Resize<String>(ref risDenied, j + 1);
                Array.Resize<String>(ref risID, j + 1);
                System.Diagnostics.Debug.WriteLine(data[j]);
                String[] words = data[j].Split(',');
                projectID[j] = words[0];
                projectName[j] = words[1];
                fileName[j] = words[2];
                firstName[j] = words[3];
                lastName[j] = words[4];
                department[j] = words[5];
                risDenied[j] = words[6];
                //risID[j] = words[7];
                System.Diagnostics.Debug.WriteLine(projectID[j]);
                System.Diagnostics.Debug.WriteLine(projectName[j]);
                System.Diagnostics.Debug.WriteLine(fileName[j]);
                System.Diagnostics.Debug.WriteLine(firstName[j]);
                System.Diagnostics.Debug.WriteLine(lastName[j]);
                System.Diagnostics.Debug.WriteLine(department[j]);
                System.Diagnostics.Debug.WriteLine(risDenied[j]);

            }
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
                    //Response.Redirect("ris.aspx");
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

        protected void Accepted(object sender, EventArgs e)
        {
            string projectID = projID.Text;
            string userID = (string)Session["StaffNo"];
            string role = getRole();

            Button button = (Button)sender;
            DB db = new DB();

            string updateSigned = "UPDATE 17agileteam6db.projects SET " + role + "_accepted = 1 WHERE project_ID = " + projectID;
            string updateIDSigned = "UPDATE 17agileteam6db.projects SET " + role + "_ID =" + userID + " WHERE project_ID = " + projectID;
            db.Insert(updateSigned);
            db.Insert(updateIDSigned);
            db.History(Int32.Parse(projectID), role, "Signed", "Project Has been Signed");
            db.Email("s.burns@dundee.ac.ukk", "Project " + projectID + "awaiting signing");
        }


        private string getRole()
        {
            string role = (string)Session["role"];
            switch (role)
            {
                case "1":
                    return "RIS";
                case "2":
                    return "ass_dean";
                case "3":
                    return "dean";
            }
            return " ";
        }

        public void Upload(object sender, System.EventArgs e)
        {
            string projectID = projID.Text;
            Response.Redirect("~/UploadProject.aspx");
        }


        public void Download(object sender, System.EventArgs e)
        {
            string projectID = projID.Text;
            Response.Redirect("~/DownloadProjectPage.aspx");
        }
    }
}