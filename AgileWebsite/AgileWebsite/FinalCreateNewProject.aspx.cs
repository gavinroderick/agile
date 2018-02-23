using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class FinalCreateNewProject : System.Web.UI.Page
    {
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

                    Label2.Text = dateTimeCorrectFormat;
                
                    query = "INSERT INTO files (file_name, date_uploaded, actual_file) VALUES ('" + fn + "', '" + DateTime.Now + "', " + FileUpload1.PostedFile + ")";
                    string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '" + dateTimeCorrectFormat + "')";
                    string query3 = "INSERT INTO files (file_name, date_uploaded) VALUES ('" + fn + "', '2001-09-08 12:54')";
                    string part1 = "INSERT INTO files (file_name) VALUES ('" + fn + "')";
                    string part2 = "INSERT INTO files (date_uploaded) VALUES ('" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day +" " + DateTime.Now.Hour + ":" + DateTime.Now.Minute +":" + DateTime.Now.Second + "')";
                    string part3 = "INSERT INTO files (actual_file) VALUES (" + FileUpload1.PostedFile + ")";
                    //string query2 = "INSERT INTO files (file_name, date_uploaded) VALUES ('scot2', '1111-11-11 20:20')";
                    //db.Insert(part1);
                    db.Insert(query2);
                    db.Insert(part3);

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