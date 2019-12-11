using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace Main_computer
{
    public class Database
    {
        public string ConnectionString { get; private set; }
        private MySqlConnection Connection;

        public Database(string connectionString = "Server=studmysql01.fhict.local;Uid=dbi413213;Database=dbi413213;Pwd=helmond;")
        {
            ConnectionString = connectionString;
            Connection = new MySqlConnection(connectionString);
        }

        public DbCheck IsDatabaseReachable()
        {
            try
            {
                Connection.Open();
                Connection.Close();
                return new DbCheck(true);
            }
            catch (MySqlException ex)
            {
                return new DbCheck(false, ex);
            }
        }

        public bool Registrate(string firstName, string lastName, DateTime date_of_birth, string email_address, string password, Address address)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO users (`first_name`, `last_name`, `date_of_birth`, `email_address`, `password`, `physical_address`) VALUES (@1, @2, @3, @4, @5, @6);";
            cmd.Parameters.AddWithValue("@1", firstName);
            cmd.Parameters.AddWithValue("@2", lastName);
            cmd.Parameters.AddWithValue("@3", date_of_birth);
            cmd.Parameters.AddWithValue("@4", email_address);
            cmd.Parameters.AddWithValue("@5", password);
            cmd.Parameters.AddWithValue("@6", address);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Connection.Close();
                return true;
            }
            else
            {
                Connection.Close();
                return false;
            }
        }

        public string RetrieveUserID(string email_address)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `userid` FROM `users` WHERE email_address = @1;";
            cmd.Parameters.AddWithValue("@1", email_address);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            string userid;
            if (reader.HasRows)
            {
                reader.Read();
                userid = reader.GetString(0);
            }
            else
            {
                userid = "null";
            }
            Connection.Close();
            return userid;
        }

        public User GetUser(string userid)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM `users` WHERE `userid` LIKE @1;";
            cmd.Parameters.AddWithValue("@1", userid);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                string first_name = reader.GetString(1);
                string last_name = reader.GetString(2);
                DateTime date_of_birth = reader.GetDateTime(3);
                string email_address = reader.GetString(4);
                string password = reader.GetString(5);
                Address address = GetAddress(reader.GetString(6));
                decimal balance = reader.GetDecimal(7);
                Connection.Close();
                return new User(first_name, 
                    last_name, 
                    date_of_birth, 
                    email_address, 
                    password, 
                    address, 
                    balance);
            }
            else
            {
                return null;
            }
            
        }

        private Address GetAddress(string address)
        {
            List<int> commas = CommaIndexes(address);
            string street = address.Substring(0, address.IndexOf(' '));
            string number = address.Substring(street.Length + 1, commas[0] - street.Length - 1);
            string zipcode = address.Substring(commas[0] + 2, commas[1] - commas[0] - 2);
            string city = address.Substring(commas[1] + 2, commas[2] - commas[1] - 2);
            string country = address.Substring(commas[2] + 2);
            return new Address(street, number, zipcode, city, country);
        }

        private List<int> CommaIndexes(string s)
        {
            List<int> indexes = new List<int>();
            char[] s_array = s.ToCharArray();
            for (int i = 0; i < s_array.Length; i++)
            {
                if (s_array[i] == ',')
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        public bool EmailAlreadyInUse(string email_address)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `email_address` FROM `users` WHERE email_address LIKE @1;";
            cmd.Parameters.AddWithValue("@1", email_address);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                Connection.Close();
                return true;
            }
            Connection.Close();
            return false;
        }

        public string RetrievePassword(string email_address)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `password` FROM `users` WHERE email_address LIKE @1;";
            cmd.Parameters.AddWithValue("@1", email_address);
            Connection.Open();
            var reader = cmd.ExecuteReader();
            string password;
            if (reader.HasRows)
            {
                reader.Read();
                password = reader.GetString(0);
            }
            else
            {
                password = "null";
            }
            Connection.Close();
            return password;
        }

        public bool UpdateUserDetails(string userid, string[] columnNames, string[] newValues)
        {
            string query = "UPDATE `users` SET ";
            for (int i = 0; i < columnNames.Length; i++)
            {
                if ((i + 1) == columnNames.Length)
                {
                    query += $"{columnNames[i]} = '{newValues[i]}' ";
                }
                else
                {
                    query += $"{columnNames[i]} = '{newValues[i]}', ";
                }
            }
            query += $"WHERE userid = {userid}";
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = query;
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            return rowsAffected > 0;
        }

        public bool ChangeBalance(string userid, decimal addingValue)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "UPDATE `users` SET `balance` = balance + @1 WHERE userid = @2;";
            cmd.Parameters.AddWithValue("@1", addingValue);
            cmd.Parameters.AddWithValue("@2", userid);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public decimal GetUserBalance(string userid)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `balance` FROM `users` WHERE userid = @1";
            cmd.Parameters.AddWithValue("@1", userid);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                decimal balance = reader.GetDecimal(0);
                Connection.Close();
                return balance;
            }
            else
            {
                Connection.Close();
                return 0;
            }
        }

        public bool AutoLockBikeStand(string stand_id, string verification_key)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO sessions (`stand_id`, `lock_moment`, `verification_key`) VALUES(@1, @2, @3);";
            cmd.Parameters.AddWithValue("@1", stand_id);
            cmd.Parameters.AddWithValue("@2", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cmd.Parameters.AddWithValue("@3", verification_key);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool LockBikeStand(LockProcedure lp)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "INSERT INTO `sessions`(`userid`, `stand_id`, `lock_moment`, `verification_key`) VALUES (@1, @2, @3, @4); UPDATE stands SET taken = true WHERE stand_id = @1;";
            cmd.Parameters.AddWithValue("@1", lp.StandID);
            cmd.Parameters.AddWithValue("@2", lp.UserID);
            cmd.Parameters.AddWithValue("@3", DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cmd.Parameters.AddWithValue("@4", lp.Key);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public string GetStandID_linkedToKey(string verification_key)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `stand_id` FROM `sessions` WHERE verification_key = @1";
            cmd.Parameters.AddWithValue("@1", verification_key);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            string stand_id;
            if (reader.HasRows)
            {
                reader.Read();
                stand_id = reader.GetString(0);
                Connection.Close();
                return stand_id;
            }
            else
            {
                Connection.Close();
                return null;
            }
        }

        public bool UserPaidForBikeStand(string verification_key)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "UPDATE `sessions` SET lock_moment = lock_moment, unlock_moment = @1, has_paid = !has_paid WHERE verification_key = @2;";
            cmd.Parameters.AddWithValue("@1", DateTime.Now.ToString());
            cmd.Parameters.AddWithValue("@2", verification_key);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool UserPaidForBikeStand(string verification_key, string userid)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "UPDATE `sessions` lock_moment = lock_moment, unlock_moment = now(), has_paid = !has_paid WHERE verification_key = @2;";
            cmd.Parameters.AddWithValue("@1", userid);
            cmd.Parameters.AddWithValue("@2", verification_key);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public bool AddUserIDforExistingSession(string verification_key, string userid)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "UPDATE `sessions` SET userid = @1 WHERE verification_key = @2;";
            cmd.Parameters.AddWithValue("@1", userid);
            cmd.Parameters.AddWithValue("@2", verification_key);
            Connection.Open();
            int rowsAffected = cmd.ExecuteNonQuery();
            Connection.Close();
            if (rowsAffected > 0)
            {
                return true;
            }
            return false;
        }

        public string GetVerificationKey(string userid)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `verification_key` FROM `sessions` WHERE userid = @1 AND has_paid = 0 GROUP BY sessionid DESC LIMIT 1;";
            cmd.Parameters.AddWithValue("@1", userid);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            string verification_key;
            if (reader.HasRows)
            {
                reader.Read();
                verification_key = reader.GetString(0);
            }
            else
            {
                verification_key = null;
            }
            Connection.Close();
            return verification_key;
        } 

        public string GetPrice(string verification_key)
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `lock_moment` FROM `sessions` WHERE `verification_key` = @1";
            cmd.Parameters.AddWithValue("@1", verification_key);
            Connection.Open();
            cmd.ExecuteNonQuery();
            MySqlDataReader reader = cmd.ExecuteReader();
            double minutes = 0;
            if (reader.HasRows)
            {
                reader.Read();
                minutes = MinutesDifference(reader.GetDateTime(0).Ticks, DateTime.Now.Ticks);
            }
            else
            {
                minutes = -1;
            }
            double pricePerMinute = 0.05; //5 cent per minute
            double price = pricePerMinute * minutes;
            if (price < 0)
            {
                return null;
            }
            return price.ToString();
        }

        private double MinutesDifference(long start, long end)
        {
            return new TimeSpan(end - start).TotalMinutes;
        }

        public List<string> LoadStandIDs()
        {
            MySqlCommand cmd = Connection.CreateCommand();
            cmd.CommandText = "SELECT `stand_id` FROM `stands`;";
            Connection.Open();
            List<string> stand_ids = new List<string>();
            MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
            if (adapter != null)
            {
                DataTable dt = new DataTable();
                adapter.Fill(dt);   
                foreach (DataRow row in dt.Rows)
                {
                    stand_ids.Add(row[0].ToString());
                }
            }
            else
            {
                stand_ids = null;
            }
            Connection.Close();
            return stand_ids;
        }
    }
}
