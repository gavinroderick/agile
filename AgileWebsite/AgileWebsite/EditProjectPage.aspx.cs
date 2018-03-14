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
    public partial class EditProjectPage : Page
    {
        void Page_Load(Object sender, EventArgs e)
        {
           //string fileName = textBox1.Text      
            // Manually register the event-handling method for
            // the Click event of the Button control.
            //     DownloadButton.Click += new EventHandler(this.DownloadButton_Click);

        }
       
        public void DownloadFromDatabase()
        {
            MySql.Data.MySqlClient.MySqlConnection conn;
            MySql.Data.MySqlClient.MySqlCommand cmd;
            MySql.Data.MySqlClient.MySqlDataReader myData;
            conn = new MySql.Data.MySqlClient.MySqlConnection();
            cmd = new MySql.Data.MySqlClient.MySqlCommand();
            string SQL;
            UInt32 FileSize;
            byte[] rawData;
            FileStream fs;
            conn.ConnectionString = "server=silva.computing.dundee.ac.uk;uid=17agileteam6;" +
                "pwd=7845.at6.5487;database=17agileteam6db";
            SQL = "SELECT file_name, file_size, actual_file FROM file";
         
                conn.Open();
                cmd.Connection = conn;
                cmd.CommandText = SQL;
                myData = cmd.ExecuteReader();
                if (!myData.HasRows)
                    throw new Exception("There are no BLOBs to save");
                myData.Read();
                FileSize = myData.GetUInt32(myData.GetOrdinal("file_size"));
                rawData = new byte[FileSize];
                myData.GetBytes(myData.GetOrdinal("file"), 0, rawData, 0, (int)FileSize);
                fs = new FileStream(@"C:\newfile.xlsx", FileMode.OpenOrCreate, FileAccess.Write);
                fs.Write(rawData, 0, (int)FileSize);
                fs.Close();            
                myData.Close();
                conn.Close();
          
        }
        public void Button1_Click(object sender, System.EventArgs e)
        {
           

            Button clickedButton = (Button)sender;

            
            //  string File =
                  string File = fileName.Text + ".xlsx";
                 this.Download(File);
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
    }
}