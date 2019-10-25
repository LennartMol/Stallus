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
            command.CommandText = "SELECT password FROM login WHERE username = @1";
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
    }
}
