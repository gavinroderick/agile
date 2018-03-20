using MySql.Data.MySqlClient;
using System;

namespace AgileWebsite
{
    public partial class Project : System.Web.UI.Page
    {
        MySqlDataReader read;
        MySqlDataReader read2;
        public string projectID;
        public int fileID;
        public string researcherID;
        public string projectInfo;
        public string dateSubmitted;
        public string projectName;
        public int currentStage;

        public string researcherName;
        public string department;
        public string email;

        public string stage;
        public string fileName;
        public string fileUploaded;
        public int fileSize;

        public string userRole = "999";
        protected void Page_Load(object sender, EventArgs e)
        {
            projectID = Request.QueryString["id"];
            if(projectID == null)
            {
                projectID = "21";
            }
            int projID = int.Parse(projectID);
            getUserDetails();

            getProjectDetails(projID);
            getResearcherDetails(researcherID);
            currentStage = getCurrentStage(projID);
        }

        public void getUserDetails()
        {
            string LI = (String)Session["loggedin"];
            if(LI == "Loggedin")
            {
                userRole = (String)Session["role"];
            }
        }
        private void getProjectDetails(int projID)
        {
            DB db = new DB();
            string projectQuery = "SELECT * FROM PROJECTS WHERE project_ID = '" + projectID + "';";
            string fileQuery = "SELECT * FROM FILES WHERE file_id = " + fileID + ";";
            read =  db.Select(projectQuery);
            if (read.HasRows && read.Read())
            {
                fileID = read.GetInt16("file_ID");
                researcherID = read.GetString("researcher_ID");
                projectInfo = read.GetString("project_info");
                projectName = read.GetString("project_name");
                dateSubmitted = read.GetString("date_submitted");
            }
            db.CloseConnection();
            read = db.Select(fileQuery);
            if (read.HasRows && read.Read())
            {
                fileName = read.GetString("file_name");
                fileUploaded = (String)read.GetString("date_uploaded");
                fileSize = read.GetInt32("file_size");
            }

        }

        private void getResearcherDetails(string researcherID)
        {
            DB db = new DB();

            string researcherQuery = "SELECT * FROM USERS WHERE staff_no = '" + researcherID + "';";

            read2 = db.Select(researcherQuery);
            if (read.HasRows && read2.Read())
            {
                string firstName = read2.GetString("first_name");
                string lastName = read2.GetString("last_name");
                researcherName = firstName + " " + lastName;
                department = read2.GetString("department");
                email = read2.GetString("email");
            }
        }

        private int getCurrentStage(int projID)
        {
            int risDenied;
            int ris;
            int assAccept;
            int deanAccept;
            int finalAccept;
            int total;

            DB db = new DB();
            string stageQuery = "SELECT RIS_denied, RIS_accepted, ass_dean_accepted, dean_accepted, researcher_final_accept from projects WHERE project_ID = 21;";
            read = db.Select(stageQuery);
            if (read.HasRows && read.Read())
            {
                risDenied = read.GetInt16("RIS_denied");
                ris = read.GetInt16("RIS_accepted");
                assAccept = read.GetInt16("ass_dean_accepted");
                deanAccept = read.GetInt16("dean_accepted");
                finalAccept = read.GetInt16("researcher_final_accept");

                total = ris + assAccept + deanAccept + finalAccept;

                if (risDenied == 1)
                {
                    return risDenied;
                }
                return total;
            }
            else return 0;
           
        }
    }
}