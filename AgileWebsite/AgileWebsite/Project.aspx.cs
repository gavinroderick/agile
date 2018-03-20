using MySql.Data.MySqlClient;
using System;
using System.Web.UI.WebControls;

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
        public string currentStage;

        public string researcherName;
        public string department;
        public string email;
        int projID;

        public string stage;
        public string fileName;
        public string fileUploaded;
        public int fileSize;

        public int[] commentID;
        public string[] userComment;
        public string[] commentDate;
        public string[] commentProjectAction;
        public string[] comments;
        public int arrayLength;
        public int userRole;
        protected void Page_Load(object sender, EventArgs e)
        {
            projectID = Request.QueryString["id"];
            if(projectID == null)
            {
                projectID = "21";
            }
            projID = int.Parse(projectID);
            getUserDetails();

            getProjectDetails(projID);
            getResearcherDetails(researcherID);
            currentStage = getCurrentStage(projID);
        }

        public void getUserDetails()
        {
            string LI = (String)Session["loggedin"];
            if (LI == "Loggedin")
            {
                string staffNo = (string)Session["StaffNo"];
                DB db = new DB();
                string query = "SELECT * FROM 17agileteam6db.users WHERE staff_no='" + staffNo + "';";
                read = db.Select(query);
                if (read.HasRows && read.Read())
                {
                    userRole = read.GetInt16("role");
                }
            }
            
        }
        private void getProjectDetails(int projID)
        {
            DB db = new DB();
            string projectQuery = "SELECT * FROM PROJECTS INNER JOIN files ON projects.file_ID = files.file_ID WHERE project_ID ='" + projectID + "';";
            string fileQuery = "SELECT * FROM FILES WHERE file_id = " + fileID + ";";
            read =  db.Select(projectQuery);
            if (read.HasRows && read.Read())
            {
                fileID = read.GetInt16("file_ID");
                researcherID = read.GetString("researcher_ID");
                projectInfo = read.GetString("project_info");
                projectName = read.GetString("project_name");
                dateSubmitted = read.GetString("date_submitted");
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

        private string getCurrentStage(int projID)
        {
            int risDenied;
            string ris;
            int assAccept;
            int deanAccept;
            int finalAccept;

            DB db = new DB();
            string stageQuery = "SELECT RIS_denied, RIS_accepted, ass_dean_accepted, dean_accepted, researcher_final_accept from projects WHERE project_ID = 21;";
            read = db.Select(stageQuery);
            if (read.HasRows && read.Read())
            {
                risDenied = read.GetInt16("RIS_denied");
                ris = read.GetString("RIS_accepted");
                assAccept = read.GetInt16("ass_dean_accepted");
                deanAccept = read.GetInt16("dean_accepted");
                finalAccept = read.GetInt16("researcher_final_accept");

                if (risDenied == 1)
                {
                    return "Denied";
                }
                else if (ris == "1")
                {
                    return "RIS";
                }
                else if(assAccept == 1)
                {
                    return "assDean";
                }
                else if(deanAccept == 1)
                {
                    return "dean";
                }
                else if(finalAccept == 1)
                {
                    return "finished";
                }
                
            }
            return "Waiting for RIS to approve";

        }
        protected void finalFunded(object sender, EventArgs e)
        {
            DB db = new DB();
            string query = "UPDATE `17agileteam6db`.`projects` SET `researcher_final_accept`='1' WHERE `project_ID`=" + projectID + ";";
            db.Update(query);
            Response.Redirect("Project.aspx?id=" + projID);
        }

        protected void Accepted(object sender, EventArgs e)
        {
            string userID = (string)Session["StaffNo"];
            string role = getRole();

            Button button = (Button)sender;
            DB db = new DB();

            string updateSigned = "UPDATE 17agileteam6db.projects SET " + role + "_accepted = 1 WHERE project_ID = " + projID;
            string updateIDSigned = "UPDATE 17agileteam6db.projects SET " + role + "_ID ='" + userID + "' WHERE project_ID = " + projID;
            db.Update(updateSigned);
            db.Update(updateIDSigned);
            Response.Redirect("/Index.aspx");
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

            string updateSigned = "UPDATE 17agileteam6db.projects SET RIS_denied = 1 WHERE project_ID = " + projID;
            string historyQuery = "INSERT INTO 17agileteam6db.history(project_ID, user, date_time, projectAction, Comments) " + "VALUES (" + projID + ",'" + userID + "','" + dateTime + "','" + "Denied', '" + comments + "');";
            //string updateIDSigned = "UPDATE 17agileteam6db.projects SET " + role + "_ID =" + userID + " WHERE project_ID = " + projectID;
            db.Update(updateSigned);
            db.Insert(historyQuery);
            //db.Update(updateIDSigned);
            Response.Redirect("/Index.aspx");
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
    }
}