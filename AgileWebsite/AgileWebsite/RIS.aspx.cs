using MySql.Data.MySqlClient;
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
        public String[] risID = new String[1];
        protected void Page_Load(object sender, EventArgs e)
        {
            DB dB = new DB();
            String query = "SELECT project_ID, project_name, files.file_name, users.first_name, users.last_name, users.department, RIS_ID FROM PROJECTS JOIN users ON researcher_ID = users.staff_no JOIN files ON projects.file_ID = files.file_ID; ";
            //String query = "SELECT project_ID, files.file_name, users.first_name, users.last_name, users.department, RIS_ID FROM PROJECTS JOIN users ON researcher_ID = users.staff_no JOIN files ON projects.file_ID = files.file_ID;";
            //String[] projectID = new String[1];
            //String[] fileName = new String[1];
            //String[] firstName = new String[1];
            //String[] lastName = new String[1];
            //String[] risID = new String[1];


            /*
             * project id
             * file name
             * 
             * 
             */
            //String[] rows = new String[1];
            int i = 0;

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

        protected void Accepted(object sender, EventArgs e)
        {
            
        }
    }
}