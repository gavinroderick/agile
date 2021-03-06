﻿using MySql.Data.MySqlClient;
using System;
using System.Net.Mail;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AgileWebsite
{

    public class DB
    {
        private MySqlConnection connection;
        private MySqlCommand command;
        private MySqlDataReader reader;

        //Constructor
        public DB()
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
        private bool OpenConnection()
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

        public void OpenConnectionForScott()
        {
            OpenConnection();
        }

        public MySqlConnection GetConnectionStringForScott()
        {
            return connection;
        }

        //Close connection
        public bool CloseConnection()
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

        public void CloseConnectionForScott()
        {
            CloseConnection();
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


        // Might work, slightly tested so far
        public void Insert(string sql)
        {
            try 
            {
                OpenConnection();
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
                OpenConnection();
                command = new MySqlCommand(sql, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        public void History(int project_ID, string user, string action, string comment)
        {

            string query = "INSERT INTO 17agileteam6db.history (project_ID, user, Historycol, date_time, projectAction, Comments) VALUES (" + project_ID + ", '" + user + "', ' ', NOW(), '" + action + "', '" + comment + "')";

            Insert(query);
        }

        //Creates email and sends to email given with given message
        public void Email(string toEmail, string message)
        {
            try
            {
                MailMessage mail = new MailMessage("team6agile@gmail.com", toEmail); //creates email
                SmtpClient client = new SmtpClient("smtp.gmail.com")// Sends from Gmail
                {
                    Port = 587,
                    Credentials = new System.Net.NetworkCredential("team6agile@gmail.com", "AgileTeam6"), //gmail Account credentials
                    EnableSsl = true

                };
                mail.Subject = "Don't Reply: Project Alert.";
                mail.Body = message;
                client.Send(mail); //sends Email
            }
            catch
            {
                Console.Write("Something went wrong");
            }
        }
    }
}