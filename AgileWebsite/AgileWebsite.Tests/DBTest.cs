using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWebsite
{

    public class DBTest
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        //Constructor
        public DBTest()
        {
            Initialize();
        }

        //Initialize values
        private void Initialize()
        {
            string server = "silva.computing.dundee.ac.uk";
            string database = "17agileteam6db";
            string uid = "17agileteam6";
            string password = "7845.at6.5487";

            string connString = "server=" + server + ";uid=" + uid + ";pwd=" + password + ";database=" + database;
            connection = new MySqlConnection(connString);
        }

        //Open connection to database
        public bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }
        
        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        //Use this to Select data from the DB
        // Takes a select statement as a string, returns a MySqlDataReader obj 
        public MySqlDataReader Select(string sql)
        {
            if (OpenConnection())
            {
                command = new MySqlCommand(sql, connection);
                reader = command.ExecuteReader();
            }
            return reader;
        }


        // Might work, untested so far
        public bool Insert(string sql)
        {
            try
            {
                OpenConnection();
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }


        //Also untested, may not work.
        public bool Update(string sql)
        {
            try
            {
                OpenConnection();
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
                CloseConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                return false;
            }
        }

        public bool History(int project_ID, string user, string action, string comment)
        {

            string query = "INSERT INTO 17agileteam6db.history (project_ID, user, Historycol, date_time, projectAction, Comments) VALUES (" + project_ID + ", '" + user + "', ' ', NOW(), '" + action + "', '" + comment + "')";

            return Insert(query);
        }
    }
}