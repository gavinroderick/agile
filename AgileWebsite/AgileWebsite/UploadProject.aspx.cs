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
    public partial class UploadProject: Page
    {
        void Page_Load(Object sender, EventArgs e)
        {
        
        }

        public void UploadToDatabase()
        {
            string query;
            DB db = new DB();
            int FileLen = uploadFile.PostedFile.ContentLength;
            string fn = System.IO.Path.GetFileName(uploadFile.PostedFile.FileName);
            byte[] input = new byte[FileLen];
            System.IO.Stream MyStream = uploadFile.PostedFile.InputStream;
            using (var binaryReader = new BinaryReader(MyStream))
            {
                input = binaryReader.ReadBytes((int)MyStream.Length);
            }

            db.OpenConnectionForScott();

            query = "UPDATE files SET actual_file = @actual_file, file_size = @FileSize WHERE file_name = @file_name";
            //query = "INSERT INTO files (file_name, actual_file, file_size) VALUES(@file_name, @actual_file, @FileSize)";         
            MySqlCommand cmd = new MySqlCommand(query, db.GetConnectionStringForScott());
            cmd.Parameters.AddWithValue("@file_name", fn);
            //cmd.Parameters.AddWithValue("@actual_file", fileToUpload);
            cmd.Parameters.Add("@actual_file", MySqlDbType.LongBlob, input.Length).Value = input;
            cmd.Parameters.AddWithValue("@FileSize", (int)input.Length);
            cmd.ExecuteNonQuery();

            db.CloseConnectionForScott();
        }


        public void Button2_Click(object sender, System.EventArgs e)
        {
            Button clickedButton = (Button)sender;            
            UploadToDatabase();
        }
    
        
    }
}