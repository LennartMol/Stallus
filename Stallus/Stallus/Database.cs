using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace Stallus
{
    public class Database
    {
        public string ConnectionString { get; private set; }
        private MySqlConnection connection;

        public Database(string connectionString)
        {
            ConnectionString = connectionString;
            connection = new MySqlConnection(connectionString);
        }

        public string StallusLogin(string username)
        {
            string retrievedPassword = "";
            connection.Open();
            MySqlCommand command = connection.CreateCommand();
            command.CommandText = "SELECT password FROM login_details WHERE username = @1";
            command.Parameters.AddWithValue("@1", username);
            var reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                retrievedPassword = reader.GetString(0);
            }
            else
            {
                connection.Close();
                return null;
            }
            connection.Close();
            return retrievedPassword;
        }

        public void StallusRegistrate(string firstName, string lastName, DateTime date_of_birth, string email, Address address, string password)
        {
            MySqlCommand commandUsers = connection.CreateCommand();
            MySqlCommand commandLogin = connection.CreateCommand();
            commandUsers.CommandText = "INSERT INTO users (`first_name`, `last_name`, `date_of_birth`, `email_address`, `physical_address`, `ballance`) VALUES (@1, @2, @3, @4, @5, 0)";
            commandUsers.Parameters.AddWithValue("@1", firstName);
            commandUsers.Parameters.AddWithValue("@2", lastName);
            commandUsers.Parameters.AddWithValue("@3", date_of_birth);
            commandUsers.Parameters.AddWithValue("@4", email);
            commandUsers.Parameters.AddWithValue("@5", address);
            commandUsers.Connection = connection;

            commandLogin.CommandText = "INSERT INTO login_details(userid, username, password) " +
                "SELECT userid, email, @2 " +
                "FROM users " +
                "WHERE email LIKE @1";
            commandLogin.Parameters.AddWithValue("@1", email);
            commandLogin.Parameters.AddWithValue("@2", password);


            try
            {
                connection.Open();
                commandUsers.ExecuteNonQuery();
                commandLogin.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                connection.Close();
            }
        }

        public string StallusRegister()
        {
            return null;
        }
    }
}
