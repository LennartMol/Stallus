using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using MySql;

namespace Main_computer
{
    public class Database
    {
        public string ConnectionString { get; private set; }
        private MySqlConnection connection;

        public Database(string connectionString = "Server=studmysql01.fhict.local;Uid=dbi413213;Database=dbi413213;Pwd=helmond;")
        {
            ConnectionString = connectionString;
            connection = new MySqlConnection(connectionString);
        }
        
        public bool IsDatabaseReachable()
        {
            try
            {
                connection.Open();
                connection.Close();
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public bool Registrate(string firstName, string lastName, DateTime date_of_birth, string email, string password, Address address)
        {
            MySqlCommand cmd_checkEmail = connection.CreateCommand();
            cmd_checkEmail.CommandText = "SELECT email_address FROM users WHERE email_address = @1";
            cmd_checkEmail.Parameters.AddWithValue("@1", email);
            connection.Open();
            cmd_checkEmail.ExecuteNonQuery();
            MySqlDataReader reader = cmd_checkEmail.ExecuteReader();
            if (reader.HasRows)
            {
                return false;
            }
            connection.Close();

            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "INSERT INTO users (`first_name`, `last_name`, `date_of_birth`, `email_address`, `password`, `physical_address`) VALUES (@1, @2, @3, @4, @5, @6)";
            cmd.Parameters.AddWithValue("@1", firstName);
            cmd.Parameters.AddWithValue("@2", lastName);
            cmd.Parameters.AddWithValue("@3", date_of_birth);
            cmd.Parameters.AddWithValue("@4", email);
            cmd.Parameters.AddWithValue("@5", password);
            cmd.Parameters.AddWithValue("@6", address);
            cmd.Connection = connection;
            connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                connection.Close();
                return true;
            }
            else
            {
                return false;
            }
        }

        public string RetrievePassword(string username)
        {
            MySqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT password FROM users WHERE username = @1";
            cmd.Parameters.AddWithValue("@1", username);
            connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            string password;
            if (reader.HasRows)
            {
                reader.Read();
                password = reader.GetString(0);
            }
            else
            {
                connection.Close();
                return "null";
            }
            connection.Close();
            return password;
        }

        public string Register()
        {
            return null;
        }
    }
}
