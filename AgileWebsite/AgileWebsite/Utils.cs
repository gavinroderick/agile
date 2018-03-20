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
    public class Utils
    {
        // Params: String filename - takes the filename without the xlsx
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
                //conn.Open();
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
    }
}