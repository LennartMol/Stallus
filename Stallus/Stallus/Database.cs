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

        public void StallusRegistrate(Customer customer)
        {
            MySqlCommand commandUsers = connection.CreateCommand();
            MySqlCommand commandLogin = connection.CreateCommand();
            commandUsers.CommandText = "INSERT INTO users (`first_name`, `last_name`, `date_of_birth`, `email_address`, `physical_address`, `balance`) VALUES (@1, @2, @3, @4, @5, 0)";
            commandUsers.Parameters.AddWithValue("@1", customer.FirstName);
            commandUsers.Parameters.AddWithValue("@2", customer.LastName);
            commandUsers.Parameters.AddWithValue("@3", customer.DateOfBirth);
            commandUsers.Parameters.AddWithValue("@4", customer.Email);
            commandUsers.Parameters.AddWithValue("@5", customer.Address);
            commandUsers.Connection = connection;

            commandLogin.CommandText = "INSERT INTO login_details(userid, username, password) " +
                "SELECT userid, email_address, @2 " +
                "FROM users " +
                "WHERE email_address LIKE @1";
            commandLogin.Parameters.AddWithValue("@1", customer.Email);
            commandLogin.Parameters.AddWithValue("@2", customer.Password);



                connection.Open();
                commandUsers.ExecuteNonQuery();
                commandLogin.ExecuteNonQuery();
                connection.Close();

        }

    }
}
