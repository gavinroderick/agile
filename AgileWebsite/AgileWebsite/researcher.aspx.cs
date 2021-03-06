﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class researcher : System.Web.UI.Page
    {
       
        MySqlDataReader reader;
        public String[] data = new String[1];
        public String[] projectID = new String[1];
        public String[] projectName = new string[1];
        public String[] fileName = new String[1];
        public String[] firstName = new String[1];
        public String[] lastName = new String[1];
        public String[] department = new String[1];
        public String[] RIS_accepted = new String[1];
        public String[] ass_dean_accepted = new String[1];
        public String[] dean_accepted = new String[1];
        public String[] RIS_denied = new String[1];




        protected void Page_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
                    
            String query = "SELECT project_ID, project_name, files.file_name, users.first_name, users.last_name, users.department, projects.RIS_accepted, projects.ass_dean_accepted, projects.dean_accepted, projects.RIS_denied  FROM PROJECTS  JOIN users ON researcher_ID = users.staff_no  JOIN files ON projects.file_ID = files.file_ID WHERE projects.researcher_ID ='" + (string)Session["StaffNo"] + "'";
            //(RIS_accepted = 0 OR RIS_accepted is NULL)

            //  String queryImage = "SELECT RIS_accepted, ass_dean_accepted, dean_accepted FROM projects";

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
                        for (int n = 0; n < 10; n++)
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
                Array.Resize<String>(ref RIS_accepted, j + 1);
                Array.Resize<String>(ref ass_dean_accepted, j + 1);
                Array.Resize<String>(ref dean_accepted, j + 1);
                Array.Resize<String>(ref RIS_denied, j + 1);



                System.Diagnostics.Debug.WriteLine(data[j]);
                String[] words = data[j].Split(',');
                projectID[j] = words[0];
                projectName[j] = words[1];
                fileName[j] = words[2];
                firstName[j] = words[3];
                lastName[j] = words[4];
                department[j] = words[5];
                RIS_accepted[j] = words[6];
                ass_dean_accepted[j] = words[7];
                dean_accepted[j] = words[8];
                RIS_denied[j] = words[9];
                //risID[j] = words[6];
                System.Diagnostics.Debug.WriteLine(projectID[j]);
                System.Diagnostics.Debug.WriteLine(projectName[j]);
                System.Diagnostics.Debug.WriteLine(fileName[j]);
                System.Diagnostics.Debug.WriteLine(firstName[j]);
                System.Diagnostics.Debug.WriteLine(lastName[j]);
                System.Diagnostics.Debug.WriteLine(department[j]);
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
                    //Response.Redirect("Researcher.aspx");
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

        protected void Accepted(object sender, EventArgs e)
        {
            //string projectID = projID.Text;
            string userID = (string)Session["StaffNo"];
            string role = getRole();

            Button button = (Button)sender;
            DB db = new DB();

            string updateSigned = "UPDATE 17agileteam6db.projects SET " + role + "_accepted = 1 WHERE project_ID = " + projectID;
            string updateIDSigned = "UPDATE 17agileteam6db.projects SET " + role + "_ID =" + userID + " WHERE project_ID = " + projectID;
            db.Update(updateSigned);
            db.Update(updateIDSigned);
        }

        protected void Denied(object sender, EventArgs e)
        {
            //string projectID = projID.Text;
            string userID = (string)Session["StaffNo"];
            string name = (string)Session["firstName"] + " " + (string)Session["lastName"];
            string role = getRole();
            string comments = "no comment";
            string dateTime = getDateTime();
            Button button = (Button)sender;
            DB db = new DB();

            string updateSigned = "UPDATE 17agileteam6db.projects SET RIS_denied = 1 WHERE project_ID = " + projectID;
            string historyQuery = "INSERT INTO 17agileteam6db.history(project_ID, user, date_time, projectAction, Comments) " + "VALUES ('" + projectID + "','" + userID + "','" + dateTime + "','" + "Denied', '" + comments + "');";
            //string updateIDSigned = "UPDATE 17agileteam6db.projects SET " + role + "_ID =" + userID + " WHERE project_ID = " + projectID;
            db.Update(updateSigned);
            db.Insert(historyQuery);
            //db.Update(updateIDSigned);
        }

        private string getDateTime()
        {
            string month = DateTime.Now.Month.ToString();
            int monthInt = Int32.Parse(month);
            if (monthInt < 10)
            {
                month = "0" + monthInt;
            }
            string day = DateTime.Now.Day.ToString();
            int dayInt = Int32.Parse(day);
            if (dayInt < 10)
            {
                day = "0" + dayInt;
            }
            string hour = DateTime.Now.Hour.ToString();
            int hourInt = Int32.Parse(hour);
            if (hourInt < 10)
            {
                hour = "0" + hourInt;
            }
            string minute = DateTime.Now.Minute.ToString();
            int minuteInt = Int32.Parse(minute);
            if (minuteInt < 10)
            {
                minute = "0" + minuteInt;
            }

            string dateTimeCorrectFormat = DateTime.Now.Year + "-" + month + "-" + day + " " + hour + ":" + minute;
            return dateTimeCorrectFormat;
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

        public void Create(object sender, System.EventArgs e)
        {
            
            Response.Redirect("~/FinalCreateNewProject.aspx");
        }

        public void Upload(object sender, System.EventArgs e)
        {
            //string projectID = projID.Text;
            Response.Redirect("~/UploadProject.aspx");
        }


        public void Download(object sender, System.EventArgs e)
        {
            //string projectID = projID.Text;
            Response.Redirect("~/DownloadProjectPage.aspx");
        }


       

    }

}
    