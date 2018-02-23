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
        protected string MyString;

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string query;
            DB db = new DB();
            if (FileUpload1.HasFile)
            try
            {
                    string fn = System.IO.Path.GetFileName(FileUpload1.PostedFile.FileName);
                    string SaveLocation = Server.MapPath("~/Projects/" + fn);

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

                    Label2.Text = FileUpload1.FileName;

                    //byte[] file = FileUpload1.FileBytes;

                    //Stream fs = FileUpload1.PostedFile.InputStream;
                    //BinaryReader br = new BinaryReader(fs);
                    //byte[] bytes123 = br.ReadBytes((Int32)fs.Length);

                    //////////////////////////////////////////////////////////////////////////////////////////////////////////////

                    //NOTE: This is the fourth refractored attempt at this code
                    //The code does not successfully open a connection to the database on this attempt
                    //This should however work better in the attempt of storing BLOB files to the database which was the problem in earlier attempts
                    //IMPORTANT*: This means we could not construct a full unit test for this part of the code
                    int FileLen = FileUpload1.PostedFile.ContentLength;
                    byte[] input = new byte[FileLen];
                    System.IO.Stream MyStream = FileUpload1.PostedFile.InputStream;
                    using (var binaryReader = new BinaryReader(MyStream))
                    {
                        input = binaryReader.ReadBytes((int)MyStream.Length);
                    }
                    string constring = "server=silva.computing.dundee.ac.uk;User ID=17agileteam6; Password=7845.at6.5487; database=17agileteam6db";
                    MySqlConnection con = new MySqlConnection(constring);

                    con.Open();
                    query = "INSERT INTO files (file_name, date_uploaded, actual_file) VALUES (@fn,@dateTimeCorrectFormat,@input)";


                    MySqlCommand c = new MySqlCommand(query);
                    c.Parameters.AddWithValue("@fn", fn);
                    c.Parameters.AddWithValue("@dateTimeCorrectFormat", dateTimeCorrectFormat);
                    c.Parameters.Add("@input", MySqlDbType.LongBlob, input.Length).Value = input;
                    int i = c.ExecuteNonQuery();

                    con.Close();


                    ////////////////////////////////////////////////////////////////////////////////
                    //ATTEMPT 1
                    ///////////////////////////////////////////////////////////////////////////////

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
                    string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '" + dateTimeCorrectFormat + "')";
                    string query3 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '2001-09-08 12:54')";
                    string part1 = "INSERT INTO files (file_name) VALUES ('" + fn + "')";
                    string part2 = "INSERT INTO files (date_uploaded) VALUES ('" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day +" " + DateTime.Now.Hour + ":" + DateTime.Now.Minute +":" + DateTime.Now.Second + "')";
                    string part3 = "INSERT INTO files (actual_file) VALUES (" + FileUpload1.PostedFile + ")";
                    //string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('scot2', '1111-11-11 20:20')";
                    //db.Insert(part1);
                    //db.Insert(query2);
                    //db.Insert(query);

                    //string query4 = "INSERT INTO projects ()";

                    //FileUpload1.SaveAs(SaveLocation);

                    Label1.Text = "File name: " +
                     FileUpload1.PostedFile.FileName + "<br>" +
                     FileUpload1.PostedFile.ContentLength + " kb<br>" +
                     "Content type: " +
                     FileUpload1.PostedFile.ContentType;
            }
            catch (Exception ex)
            {
                    Label1.Text = "ERROR: " + ex.Message.ToString();
            }
            else
            {
                Label1.Text = "You have not specified a file.";
            }
        }
    }
}