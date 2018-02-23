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
        public void Insert(string sql)
        {
            try
            {
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }


        //Also untested, may not work.
        public void Update(string sql)
        {
            try
            {
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
    }
}