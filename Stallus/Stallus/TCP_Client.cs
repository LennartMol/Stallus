using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Stallus
{
    class TCP_Client
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
                clientSock.Connect(Settings.IPAddress, Port);
                SendMessage("DB_CHECK:;");
                clientSock.Close();
                return true;
            }
            catch
            {
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
                int num = stream.Read(bytes, 0, bytes.Length);
                try
                {
                    ReceivedString = Encoding.ASCII.GetString(bytes, 0, num);
                    ReceivedString = ReceivedString.Substring(0, ReceivedString.IndexOf(';'));
                    if (ReceivedString.Contains("ACK"))
                    {
                        received = true;

                    }
                    ReceivedData = CommandStringTrimmer(ReceivedString);
                }
                catch (ArgumentOutOfRangeException)
                {
                    clientSock.Close();
                }
            }
            clientSock.Close();
        }



        public bool ReqLogin(string email_address, string password)
        {
            SendMessage($"DB_REQ_LOGIN:{email_address};");
            string rPassword = ReceivedData[2];
            if (rPassword == password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User ReqUser(string userid)
        {
            SendMessage($"DB_REQ_USER:{userid};");
            string first_name = ReceivedData[1];
            string last_name = ReceivedData[2];
            DateTime date_of_birth = ParseBirthDate(ReceivedData[3]);
            string email_address = ReceivedData[4];
            string password = ReceivedData[5];
            Address address = ParseAddress(ReceivedData[6]);
            decimal balance = Convert.ToDecimal(ReceivedData[7]);
            return new User(userid, first_name, last_name, date_of_birth, email_address, password, address, balance);
        }

        public bool Registrate(string first_name, string last_name, DateTime date_of_birth, string email, string password, Address address)
        {
            if (first_name != null && last_name != null && date_of_birth != null && password != null && address != null)
            {
                if (CheckConnection())
                {
                    SendMessage($"DB_INSERT_REGISTRATE:{first_name}/{last_name}/{date_of_birth}/{email}/{address}/{password}");
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
            List<int> indexes = UnderscoreIndexes(s);
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
            //GetMessage();
            if (ReceivedString.Contains("ACK"))
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
            if (ReceivedString.Contains("ACK"))
            {
                return true;
            }
            return false;
        }


        public string[] Req_AllStandId()
        {
            SendMessage("DB_REQ_ALLSTANDID;");
            if (ReceivedString.Contains("ACK"))
            {
                string[] allStands = ValuesStringTrimmer(ReceivedData[0]);
                return allStands;
            }
            return null;
        }

        public decimal Req_Price(User loggedInUser)
        {
            SendMessage($"DB_REQ_PRICE:{loggedInUser.UserId};");
            //GetMessage();
            if (ReceivedString.Contains("ACK"))
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
            //GetMessage();
            if (ReceivedString.Contains("ACK"))
            {
                return ReceivedData[1];
            }
            return null;
        }

        public string[] ChangeDetails(string colums, string values)
        {
            string[] columNames = ValuesStringTrimmer(colums);
            string[] newValues = ValuesStringTrimmer(values);
            string command = "DB_UPDATE_DETAILS:";
            for (int i = 0; i < columNames.Length; i++)
            {
                if (i + 1 == columNames.Length)
                {
                    command += columNames[i] + "/";
                }
                else
                {
                    command += columNames[i] + "%";
                }
            }
            for (int i = 0; i < newValues.Length; i++)
            {
                if (i + 1 == newValues.Length)
                {
                    command += newValues[i] + ";";
                }
                else
                {
                    command += newValues[i] + "%";
                }
            }
            SendMessage(command);
            //GetMessage();

            if (ReceivedString.Contains("ACK"))
            {

            }
            return null;
        }

    }
}
