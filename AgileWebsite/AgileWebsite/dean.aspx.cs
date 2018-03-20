using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class Dean : System.Web.UI.Page
    {
        //Sets variables in array
        MySqlDataReader reader;
        public String[] data = new String[1];
        public String[] projectID = new String[1];
        public String[] projectName = new string[1];
        public String[] fileName = new String[1];
        public String[] firstName = new String[1];
        public String[] lastName = new String[1];
        public String[] department = new String[1];
        public String[] risID = new String[1];
        protected void Page_Load(object sender, EventArgs e)
        {
            //Adds entry to database
            DB dB = new DB();
            String query = "SELECT project_ID, project_name, files.file_name, users.first_name, users.last_name, users.department, RIS_ID  FROM PROJECTS  JOIN users ON researcher_ID = users.staff_no  JOIN files ON projects.file_ID = files.file_ID WHERE (dean_accepted = 0 OR dean_accepted is NULL) AND ass_dean_accepted = 1";


            //CHECK FOR LOGIN
            string LI = (string)(Session["loggedin"]);
            if (LI != "Loggedin")
            {
                Response.Redirect("Index.aspx", false);
            }
            else  //Ensure that user is a Dean
            {
                DB db = new DB();
                string staffID = (string)(Session["StaffNo"]);

                Redirect(getDetails(db, staffID));
            }

            int i = 0;

            try
                // Breaks up the query into seperate variables stored in array
            {
                reader = dB.Select(query);
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int n = 0; n < 6; n++)
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
                
                //Resizes arrays based on hpw many projects are added
                Array.Resize<String>(ref projectID, j + 1);
                Array.Resize<String>(ref projectName, j + 1);
                Array.Resize<String>(ref fileName, j + 1);
                Array.Resize<String>(ref firstName, j + 1);
                Array.Resize<String>(ref lastName, j + 1);
                Array.Resize<String>(ref department, j + 1);
                Array.Resize<String>(ref risID, j + 1);
                System.Diagnostics.Debug.WriteLine(data[j]);
                String[] words = data[j].Split(',');
                projectID[j] = words[0];
                projectName[j] = words[1];
                fileName[j] = words[2];
                firstName[j] = words[3];
                lastName[j] = words[4];
                department[j] = words[5];
                //risID[j] = words[6];
                System.Diagnostics.Debug.WriteLine(projectID[j]);
                System.Diagnostics.Debug.WriteLine(projectName[j]);
                System.Diagnostics.Debug.WriteLine(fileName[j]);
                System.Diagnostics.Debug.WriteLine(firstName[j]);
                System.Diagnostics.Debug.WriteLine(lastName[j]);
                System.Diagnostics.Debug.WriteLine(department[j]);

            }
        }
        //Gets details of staff, what role they are based on ID number
        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT first_name, last_name, department, role from 17agileteam6db.users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        //Redirects user to correct page based on role
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
                    //Response.Redirect("dean.aspx");
                    break;
                default:
                    Response.Redirect("Default.aspx");
                    break;
            }
        }

        //Method which allows dean to approve a project
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
            db.Email("b.hefner@dundee.ac.uk", "Project " + projectID + "awaiting signing");
        }

        //Checks Role
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

        //Redirects to upload page
        public void Upload(object sender, System.EventArgs e)
        {
            string projectID = projID.Text;
            Response.Redirect("~/UploadProject.aspx");
        }

        //Redirects to download page
        public void Download(object sender, System.EventArgs e)
        {
            string projectID = projID.Text;
            Response.Redirect("~/DownloadProjectPage.aspx");
        }
    }
}