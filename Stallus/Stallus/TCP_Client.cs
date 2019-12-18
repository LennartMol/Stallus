using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Stallus
{
    public class TCP_Client
    {
        TcpClient clientSock;
        public int Port { get; private set; }
        public string ReceivedString { get; private set; }
        public string[] ReceivedData { get; set; }

        public TCP_Client()
        {
            Port = 13000;
            clientSock = new TcpClient();
        }

        public bool CheckConnection()
        {
            try
            {
                SendMessage("DB_CHECK:;");
                return true;
            }
            catch
            {
                clientSock.Close();
                return false;
            }
        }

        public void SendMessage(string message)
        {
            clientSock = new TcpClient();
            clientSock.Connect(Settings.IPAddress, Port);
            NetworkStream stream = clientSock.GetStream();
            byte[] data = Encoding.ASCII.GetBytes(message);
            stream.Write(data, 0, data.Length);
            byte[] bytes = new byte[1024];
            bool received = false;
            while (!received)
            {
                try
                {
                    int num = stream.Read(bytes, 0, bytes.Length);
                    ReceivedString = Encoding.ASCII.GetString(bytes, 0, num);
                }
                catch (ObjectDisposedException)
                {
                    clientSock.Close();
                }
                try
                {
                    ReceivedString = ReceivedString.Substring(0, ReceivedString.IndexOf(';'));
                }
                catch (ArgumentOutOfRangeException)
                {
                    clientSock.Close();
                }
                Console.WriteLine(ReceivedString);
                received = true;
                ReceivedData = CommandStringTrimmer(ReceivedString);
            }
            clientSock.Close();
        }



        public bool ReqLogin(string email_address, string password)
        {
            SendMessage($"DB_REQ_LOGIN:{email_address};");
            string rPassword = ReceivedData[2];
            if (ReceivedString.StartsWith("ACK"))
            {
                if (rPassword == password)
                {
                    return true;
                }
            }
            return false;
        }

        public User ReqUser(string userId)
        {
            SendMessage($"DB_REQ_USER:{userId};");
            if (ReceivedString.StartsWith("ACK"))
            {
                string first_name = ReceivedData[1];
                string last_name = ReceivedData[2];
                DateTime date_of_birth = ParseBirthDate(ReceivedData[3]);
                string email_address = ReceivedData[4];
                string password = ReceivedData[5];
                Address address = ParseAddress(ReceivedData[6]);
                decimal balance = Convert.ToDecimal(ReceivedData[7]);
                return new User(userId, first_name, last_name, date_of_birth, email_address, password, address, balance);
            }
            return null;
        }

        public bool Registrate(string first_name, string last_name, DateTime date_of_birth, string email, string password, Address address)
        {
            if (first_name != null && last_name != null && date_of_birth != null && password != null && address != null)
            {
                if (CheckConnection())
                {
                    SendMessage($"DB_INSERT_REGISTRATE:{first_name}/{last_name}/{date_of_birth.Day}_{date_of_birth.Month}_{date_of_birth.Year}/{email}/{password}/{address};");
                    if (ReceivedString.StartsWith("ACK"))
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }


        private DateTime ParseBirthDate(string s)
        {
            int day = Convert.ToInt32(s.Substring(0, 2));
            int month = Convert.ToInt32(s.Substring(3, 2));
            int year = Convert.ToInt32(s.Substring(6, 4));
            return new DateTime(year, month, day);
        }


        private Address ParseAddress(string s)
        {
            List<int> divisor_indexes = UnderscoreIndexes(s);
            string street = s.Substring(0, divisor_indexes[0]);
            string number = s.Substring(divisor_indexes[0] + 1, divisor_indexes[1] - divisor_indexes[0] - 1);
            string zipcode = s.Substring(divisor_indexes[1] + 1, divisor_indexes[2] - divisor_indexes[1] - 1);
            string city = s.Substring(divisor_indexes[2] + 1, divisor_indexes[3] - divisor_indexes[2] - 1);
            string country = s.Substring(divisor_indexes[3] + 1);
            return new Address(street, number, zipcode, city, country);
        }

        private DateTime ParseLockMoment(string s)
        {
            int hour = Convert.ToInt32(s.Substring(0, 2));
            int minutes = Convert.ToInt32(s.Substring(3, 2));
            int seconds = Convert.ToInt32(s.Substring(6, 2));
            int day = Convert.ToInt32(s.Substring(9, 2));
            int month = Convert.ToInt32(s.Substring(12, 2));
            int year = Convert.ToInt32(s.Substring(15, 4));
            return new DateTime(year, month, day, hour, minutes, seconds);
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

        private List<int> UnderscoreIndexes(string s)
        {
            List<int> indexes = new List<int>();
            char[] s_array = s.ToCharArray();
            for (int i = 0; i < s_array.Length; i++)
            {
                if (s_array[i] == '_')
                {
                    indexes.Add(i);
                }
            }
            return indexes;
        }

        public string[] CommandStringTrimmer(string stringToTrim)
        {
            if (!stringToTrim.Contains("/"))
            {
                return new string[] { stringToTrim.Substring(stringToTrim.IndexOf(':') + 1) };
            }
            return stringToTrim.Substring(stringToTrim.IndexOf(':') + 1).Split('/');
        }

        public string[] ValuesStringTrimmer(string stringToTrim)
        {
            if (!stringToTrim.Contains("%"))
            {
                return new string[] { stringToTrim };
            }
            return stringToTrim.Split('%');
        }

        public void ChangeBalance(User loggedinUser, decimal value)
        {
            SendMessage($"DB_CHANGE_BALANCE:{loggedinUser.UserId}/{value};");
            if (ReceivedString.StartsWith("ACK"))
            {
                decimal newbalance;
                if (decimal.TryParse(ReceivedData[1], out newbalance))
                {
                    loggedinUser.RaiseBalance(newbalance);
                }
            }
        }

        public bool LockBike(string standId, User loggedInUser)
        {
            SendMessage($"DB_LOCK_BIKE:{standId}/{loggedInUser.UserId};");
            if (ReceivedString.StartsWith("ACK"))
            {
                return true;
            }
            return false;
        }


        public string[] Req_AllStandId()
        {
            SendMessage("DB_REQ_ALLSTANDID;");
            if (ReceivedString.StartsWith("ACK"))
            {
                string[] allStands = ValuesStringTrimmer(ReceivedData[0]);
                return allStands;
            }
            return null;
        }

        public decimal Req_Price(User loggedInUser)
        {
            SendMessage($"DB_REQ_PRICE:{loggedInUser.UserId};");
            if (ReceivedString.StartsWith("ACK"))
            {
                decimal price;
                if (decimal.TryParse(ReceivedData[1], out price))
                    return price;
            }
            return 0;
        }


        public string Req_VerificationKey(User loggedInUser)
        {
            SendMessage($"DB_REQ_VERIFICATIONKEY:{loggedInUser.UserId};");
            if (ReceivedString.StartsWith("ACK"))
            {
                return ReceivedData[0];
            }
            return null;
        }

        public string Req_Check_Exsisting_session(User loggedInUser)
        {
            SendMessage($"DB_REQ_EXISTING_SESSION_USER:{loggedInUser.UserId};");
            if (ReceivedString.StartsWith("ACK"))
            {
                DateTime dateTime = ParseLockMoment(ReceivedData[2]);
                return dateTime.ToString("hh:mm:ss dd-MM-yyyy");
            }
            return null;
        }

        public bool ChangeDetails(User loggedInUser, List<string> columns, List<string> values)
        {
            string command = $"DB_UPDATE_DETAILS:{loggedInUser.UserId}/";
            for (int i = 0; i < columns.Count; i++)
            {
                if (i + 1 == columns.Count)
                {
                    command += columns[i] + "/";
                }
                else
                {
                    command += columns[i] + "%";
                }
            }
            for (int i = 0; i < values.Count; i++)
            {
                if (i + 1 == values.Count)
                {
                    command += values[i] + ";";
                }
                else
                {
                    command += values[i] + "%";
                }
            }
            SendMessage(command);

            if (ReceivedString.StartsWith("ACK"))
            {
                return true;
            }
            return false;
        }

    }
}
