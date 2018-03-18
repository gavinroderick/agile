using Microsoft.Win32;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AgileWebsite
{
    public partial class DownloadProjectPage: Page
    {
        void Page_Load(Object sender, EventArgs e)
        {
           
        }

        /*
        public void UploadToDatabase()
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader myData;
            conn = new MySqlConnection();
            cmd = new MySqlCommand();
            string SQL;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;

            conn.ConnectionString = "server=silva.computing.dundee.ac.uk;uid=17agileteam6;" +
               "pwd=7845.at6.5487;database=17agileteam6db";

            //Finds file based on file name
            SQL = "UPDATE files SET actual_file = @input WHERE actual_file = 'placeholder'";
            cmd.Parameters.AddWithValue("@input", FileUpload1);
            
            try
            {
                //opens connection to db
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                
                
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {

            }
        }
        */

        public bool DownloadFromDatabase(string fileName)
        {
            MySqlConnection conn;
            MySqlCommand cmd;
            MySqlDataReader myData;
            conn = new MySqlConnection();
            cmd = new MySqlCommand();
            string SQL;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;
            conn.ConnectionString = "server=silva.computing.dundee.ac.uk;uid=17agileteam6;" +
                "pwd=7845.at6.5487;database=17agileteam6db";

            //Finds file based on file name
            SQL = "SELECT file_name, file_size, actual_file FROM files WHERE file_name = @FileName";

            try
            {
                //opens connection to db
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                //appends file extension to filename input
                cmd.Parameters.AddWithValue("@FileName", fileName + ".xlsx");
                //finds file
                myData = cmd.ExecuteReader();
                myData.Read();
                //changes blob into actual file
                FileSize = myData.GetUInt32(myData.GetOrdinal("file_size"));
                rawData = new byte[FileSize];
                myData.GetBytes(myData.GetOrdinal("actual_file"), 0, rawData, 0, (int)FileSize);

                //Get path to download folder
                String path = String.Empty;
                RegistryKey rKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Internet Explorer\Main");
                if (rKey != null)
                    path = (String)rKey.GetValue("Default Download Directory");
                if (String.IsNullOrEmpty(path))
                    path = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "\\Downloads\\" + fileName + ".xlsx";
                ////

                //writes it to file in download folder
                fs = new FileStream(@path, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(rawData, 0, (int)FileSize);
                fs.Close();
                myData.Close();
                conn.Close();
                return true;
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                return false;
            }


        }
        

        public void Button1_Click(object sender, System.EventArgs e)
        {
           

            Button clickedButton = (Button)sender;
            string File = fileName.Text;
            DownloadFromDatabase(File);
            if (DownloadFromDatabase(File) == true)
            fileName.Text = "Saved to Downloads folder";
            else
            {
                fileName.Text = "File does not exist, try again";
            }
            
            

  //                
 //                this.Download(File);
            /** REFACTORED, THIS CODE MADE INTO A FUNCTION OF ITS OWN, MAKES IT REUSABLE IN OTHER PLACES
            //THIS WAS PREVIOUSLY REFACTORED ALSO
            //if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx")))
            if (System.IO.File.Exists(Server.MapPath("~/Projects/" + File)))
            {
                clickedButton.BackColor = System.Drawing.Color.AliceBlue;
                Response.ContentType = "Application/.xlsx";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + File);
                //REFACTORED CODE
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
                // Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
                Response.TransmitFile(Server.MapPath("~/Projects/" + File));
                Response.Write("This file exists.");
                Response.End();
            }
            else
            {
                Response.Write("This file doesnt exist.");
            }
            */

        }

        public void Download(string fileName)
        {


            if (System.IO.File.Exists(Server.MapPath("~/Projects/" + fileName)))
            {
                Response.ContentType = "Application/.xlsx";
                Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName);
                //REFACTORED CODE
                // Response.AppendHeader("Content-Disposition", "attachment; filename=" + fileName.Text + ".xlsx");
                // Response.TransmitFile(Server.MapPath("~/Projects/" + fileName.Text + ".xlsx"));
                Response.TransmitFile(Server.MapPath("~/Projects/" + fileName));
                Response.Write("This file exists.");
                Response.End();
            }
            else
            {
                Response.Write("This file doesnt exist.");
            }
        }

        public void returnButton_Click(object sender, System.EventArgs e)
        {
            Response.Redirect("~/ris.aspx");
        }

        public void return_finished_projects(object sender, System.EventArgs e)
        {
            Response.Redirect("~/ViewFinishedProjects.aspx");
        }

    }
}