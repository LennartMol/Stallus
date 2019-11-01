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

        public string Login(string username)
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

        public void Registrate(string firstName, string lastName, DateTime date_of_birth, string email, Address address, string password)
        {
            MySqlCommand commandUsers = connection.CreateCommand();
            MySqlCommand commandLogin = connection.CreateCommand();
            commandUsers.CommandText = "INSERT INTO users (`first_name`, `last_name`, `date_of_birth`, `email_address`, `physical_address`, `balance`) VALUES (@1, @2, @3, @4, @5, 0)";
            commandUsers.Parameters.AddWithValue("@1", firstName);
            commandUsers.Parameters.AddWithValue("@2", lastName);
            commandUsers.Parameters.AddWithValue("@3", date_of_birth);
            commandUsers.Parameters.AddWithValue("@4", email);
            commandUsers.Parameters.AddWithValue("@5", address);
            commandUsers.Connection = connection;

            commandLogin.CommandText = "INSERT INTO login_details(userid, username, password) " +
                "SELECT userid, email_address, @2 " +
                "FROM users " +
                "WHERE email_address LIKE @1";
            commandLogin.Parameters.AddWithValue("@1", email);
            commandLogin.Parameters.AddWithValue("@2", password);



            connection.Open();
            commandUsers.ExecuteNonQuery();
            commandLogin.ExecuteNonQuery();
            connection.Close();

        }

        public string Register()
        {
            return null;
        }
    }
}
