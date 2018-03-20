using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace AgileWebsite
{
    public partial class ViewFinishedProjects : System.Web.UI.Page
    {
        //Initialize parameters the class will need
        MySqlDataReader reader;
        public String[] firstName = new String[1];
        public String[] lastName = new String[1];
        public String[] department = new string[1];
        public String[] projectName = new String[1];
        public String[] RIS_accepted = new String[1];
        public String[] ass_dean_accepted = new String[1];
        public String[] dean_accepted = new String[1];
        public String[] fileName = new String[1];
        public String[] data = new String[1];
     

        protected void Page_Load(object sender, EventArgs e)
        {
            //Connect to database and pick the data we want to use from int
            DB database = new DB();
            String query = "SELECT users.first_name, users.last_name, users.department, projects.project_name, projects.RIS_accepted, projects.ass_dean_accepted, projects.dean_accepted, files.file_name FROM users, projects, files WHERE projects.RIS_accepted = 1 AND projects.ass_dean_accepted = 1 AND projects.dean_accepted = 1 AND users.staff_no = projects.researcher_ID AND files.file_ID = projects.file_ID; ";

            //CHECK FOR LOGIN
            string LI = (string)(Session["loggedin"]);
            if (LI != "Loggedin")
            {
                Response.Redirect("Index.aspx", false);
            }

            int i = 0;

            reader = database.Select(query);
            
            //Reads the data
            try
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        for (int n = 0; n < 8; n++)
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

            //Save all the data that was read into a variable that will be used to print their values on the browser
            for (int p = 0; p < i; p++)
            {
                System.Diagnostics.Debug.WriteLine("++++++++++++++++++++++++++++++++++");
                Array.Resize<String>(ref firstName, p + 1);
                Array.Resize<String>(ref lastName, p + 1);
                Array.Resize<String>(ref department, p + 1);
                Array.Resize<String>(ref projectName, p + 1);
                Array.Resize<String>(ref RIS_accepted, p + 1);
                Array.Resize<String>(ref ass_dean_accepted, p + 1);
                Array.Resize<String>(ref dean_accepted, p + 1);
                Array.Resize<String>(ref fileName, p + 1);

                System.Diagnostics.Debug.WriteLine(data[p]);

                String[] info = data[p].Split(',');
                firstName[p] = info[0];
                lastName[p] = info[1];
                department[p] = info[2];
                projectName[p] = info[3];
                RIS_accepted[p] = info[4];
                ass_dean_accepted[p] = info[5];
                dean_accepted[p] = info[6];
                fileName[p] = info[7];

                System.Diagnostics.Debug.WriteLine(firstName[p]);
                System.Diagnostics.Debug.WriteLine(lastName[p]);
                System.Diagnostics.Debug.WriteLine(department[p]);
                System.Diagnostics.Debug.WriteLine(projectName[p]);
                System.Diagnostics.Debug.WriteLine(RIS_accepted[p]);
                System.Diagnostics.Debug.WriteLine(ass_dean_accepted[p]);
                System.Diagnostics.Debug.WriteLine(dean_accepted[p]);
                System.Diagnostics.Debug.WriteLine(fileName[p]);

            }

        }
        // Redirects to the download page
        public void download_method(object sender, System.EventArgs e)
        {
            Response.Redirect("~/DownloadProjectPage.aspx");
            
        }
    }
}