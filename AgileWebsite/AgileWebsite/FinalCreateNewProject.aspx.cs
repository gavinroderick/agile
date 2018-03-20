using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using MySql.Data.MySqlClient;

namespace AgileWebsite
{
    public partial class FinalCreateNewProject : System.Web.UI.Page
    {
        //DECLARE VARIABLES NEEDED WITHIN THE WHOLE CLASS
        protected string MyString;
        MySqlDataReader reader;

        //UPON PAGE LOAD CHECK THE USER IS LOGGED IN & THEY ARE A RESEARCHER - REDIRECT IF NOT
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

        //PRIVATE METHOD - GETS & RETURNS THE ROLE OF THE CURRENTLY LOGGED IN USER (AS A STRING)
        private string getDetails(DB db, string staffID)
        {
            string roleQuery = "SELECT first_name, last_name, department, role from 17agileteam6db.users WHERE staff_no = '" + staffID + "';";
            reader = db.Select(roleQuery);
            reader.Read();
            return reader.GetString("role");
        }

        //CONTROLS REDIRECTING THE USER, IN THE CASE THAT THEY ARE NOT A RESEARCHER (USING THEIR ROLE)
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

        //CONTROLS THE UPLOADING OF A FILE TO THE DB WHEN THE UPLOAD BUTTON IS CLICKED
        protected void Button1_Click(object sender, EventArgs e)
        {
            string query;
            DB db = new DB();
            if (FileUpload1.HasFile)    //if a file was specified do this
                try
                {
                    //get filename
                    string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);

                    //validate file extention to ensure the page only accepts excel files
                    string fnExtention = System.IO.Path.GetExtension(fn);

                    //return from method if the chosen file is not in excel format (error message)
                    if (fnExtention != ".xlsx")
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Please upload an excel file type.";
                        return;
                    }
                    Label1.ForeColor = System.Drawing.Color.White;

                    //ensure there is a user logged in (otherwise return)
                    if (Session["loggedin"] == null)
                    {
                        Label1.ForeColor = System.Drawing.Color.Red;
                        Label1.Text = "Please Log in to successfully upload a file.";
                        return;
                    }

                    //get file path
                    string SaveLocation = Server.MapPath("~/Projects/" + fn);

                    //Get the time/date in the correct specified format in order to suuccessfully
                    //input this date/time into the database
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

                    //store correct date + time in a string variable
                    string dateTimeCorrectFormat = DateTime.Now.Year + "-" + month + "-" + day + " " + hour + ":" + minute;

                    Label2.Text = FileUpload1.FileName;

                    //byte[] file = FileUpload1.FileBytes;

                    //Stream fs = FileUpload1.PostedFile.InputStream;
                    //BinaryReader br = new BinaryReader(fs);
                    //byte[] bytes123 = br.ReadBytes((Int32)fs.Length);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //NOTE: This is the fourth refractored attempt at this code
                    //The code does successfully open a connection to the database on this attempt AND WORKS
                    //IMPORTANT*: This means we can now construct a full unit test for this part of the code




                    //Get file length & create a byte array variable of that length to store the uploaded file in
                    int FileLen = FileUpload1.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = FileUpload1.PostedFile.InputStream;
                    using (var binaryReader = new BinaryReader(MyStream))
                    {
                        //This actually stores the uploaded file in variable 'input'
                        input = binaryReader.ReadBytes((int)MyStream.Length);
                    }

                    //opens a database connection
                    db.OpenConnectionForScott();

                    //query string for insertion to files table
                    query = "INSERT INTO files (file_name, date_uploaded, actual_file, file_size) VALUES (@fn,@dateTimeCorrectFormat,@input,@inputLength)";

                    //query string for insertion to projects table
                    string query2 = "INSERT INTO projects (file_ID, researcher_ID,RIS_accepted,ass_dean_accepted,dean_accepted, project_info, date_submitted, project_name, RIS_ID, ass_dean_ID, dean_ID,RIS_denied, researcher_final_accept) VALUES ((SELECT MAX(file_id) FROM 17agileteam6db.files), @username,'0','0','0', @projInfo, @dateSub, @projName, '0', '0', '0','0','0')";

                    //creates the command using the query string, adds parameters and then executes the database insertion for the files table
                    MySqlCommand c = new MySqlCommand(query, db.GetConnectionStringForScott());
                    c.Parameters.AddWithValue("@fn", fn);
                    c.Parameters.AddWithValue("@dateTimeCorrectFormat", dateTimeCorrectFormat);
                    c.Parameters.Add("@input", MySqlDbType.LongBlob, input.Length).Value = input;
                    c.Parameters.AddWithValue("@inputLength", input.Length);
                    int i = c.ExecuteNonQuery();

                    //creates the command using the query string, adds parameters and then executes the database insertion for the projects table
                    MySqlCommand c2 = new MySqlCommand(query2, db.GetConnectionStringForScott());
                    c2.Parameters.AddWithValue("@username", Session["StaffNo"].ToString());
                    c2.Parameters.AddWithValue("@projInfo", ProjectInfo.Text);
                    c2.Parameters.AddWithValue("@dateSub", dateTimeCorrectFormat);
                    c2.Parameters.AddWithValue("@projName", ProjectName.Text);
                    int z = c2.ExecuteNonQuery();

                    //closes the database connection
                    db.CloseConnectionForScott();


                    //con.Close();


                    ////////////////////////////////////////////////////////////////////////////////
                    //ATTEMPT 1
                    ////////////////////////////////////////////////////////////////////////////////

                    /*MyStream.Read(input, 0, FileLen);

                for (int Loop1 = 0; Loop1 < FileLen; Loop1++)

                    MyString = MyString + input[Loop1].ToString();*/
                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //REFRACTORED - ATTEMPT 2

                    /*byte[] fileData = null;
                    using (var binaryReader = new BinaryReader(FileUpload1.PostedFile.InputStream))
                    {
                        fileData = binaryReader.ReadBytes(FileUpload1.PostedFile.ContentLength);
                    }*/

                    ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //ATTEMPT 3 - Refractorred again

                    /*BinaryReader b = new BinaryReader(FileUpload1.PostedFile.InputStream);
                    byte[] binData = b.ReadBytes(FileUpload1.PostedFile.ContentLength);*/

                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                    //part of attempt 2

                    /*using (var stream = new FileStream(FileUpload1.FileBytes(), FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            file = reader.ReadBytes((int)stream.Length);
                        }
                    }*/

                    //query = "INSERT INTO files (file_name, date_uploaded, actual_file) VALUES ('" + fn + "', '" + dateTimeCorrectFormat + "', " + MyString + ")";
                    //string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '" + dateTimeCorrectFormat + "')";
                    //string query3 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '2001-09-08 12:54')";
                    //string part1 = "INSERT INTO files (file_name) VALUES ('" + fn + "')";
                    //string part2 = "INSERT INTO files (date_uploaded) VALUES ('" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day +" " + DateTime.Now.Hour + ":" + DateTime.Now.Minute +":" + DateTime.Now.Second + "')";
                    //string part3 = "INSERT INTO files (actual_file) VALUES (" + FileUpload1.PostedFile + ")";
                    //string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('scot2', '1111-11-11 20:20')";
                    //db.Insert(part1);
                    //db.Insert(query2);
                    //db.Insert(query);

                    //string query4 = "INSERT INTO projects ()";

                    //FileUpload1.SaveAs(SaveLocation);


                    /////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //OUTPUT MESSAGE BELOW IS FOR ERROR HANDLING - SHOULD NOT BE SHOWN IN FINAL PROJECT (HARMLESS TO LEAVE IN)

                    Label1.Text = "File name: " +
                     FileUpload1.PostedFile.FileName + "<br>" +
                     FileUpload1.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     FileUpload1.PostedFile.ContentType;



                    /////////////////////////////////////////////////////////////////////////////////////////////////////

                    //PERFORMS AN INSERTION TO THE HISTORY TABLE IN THE DATABASE AND THE EMAILING TO THE RIS STAFF

                    string user = Session["StaffNo"].ToString();
                    string comment = "Uploaded the file";
                    string action = "Upload";
                    string query3 = "INSERT INTO 17agileteam6db.history (project_ID, user, date_time, projectAction, Comments) VALUES ((SELECT MAX(project_id) FROM 17agileteam6db.projects), '" + user + "', NOW(), '" + action + "', '" + comment + "')";
                    db.Insert(query3);
                    db.Email("d.Kelly@dundee.ac.uk", "New Project awaiting signing");
                    ///////////////////////////////////////////////////////////////////////////////////////////////////////

                    //REDIRECTS ONCE THE PROJECT IS SUCCESSFULLY CREATED
                    Response.Redirect("Index.aspx", false);
                }
                catch (Exception ex)
                {
                    //SHOWS EXECPTION MESSAGE ON PAGE IN THE CASE THERE IS ONE
                    Label1.Text = "ERROR: " + ex.Message.ToString();
                }
            else
            {
                //DISPLAYED IF THE USER DOES NOT SPECIFY A FILE TO BE UPLOADED
                Label1.Text = "You have not specified a file.";
            }
        }
    }
}