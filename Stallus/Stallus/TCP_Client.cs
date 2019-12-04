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
        TcpClient clientSock = null;
        public int Port { get; private set; }
        public string ReceivedString { get; private set; }
        public string[] ReceivedData { get; set; }

        public TCP_Client()
        {
            Port = 13000;
        }

        public bool CheckConnection()
        {
            try
            {
                clientSock.Connect(Settings.IPAddress, Port);
                clientSock.Close();
                clientSock.Dispose();
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
            clientSock.Close();
        }

        public void GetMessage()
        {
            byte[] bytes = new byte[1024];
            clientSock = new TcpClient();
            Console.WriteLine("Connecting to Server ...");
            clientSock.Connect(Settings.IPAddress, Port);
            Console.WriteLine("Connected !");
            NetworkStream stream = clientSock.GetStream();
            int num = stream.Read(bytes, 0, bytes.Length);
            ReceivedString = Encoding.ASCII.GetString(bytes, 0, num);
            ReceivedString = ReceivedString.Substring(0, ReceivedString.IndexOf(';'));
            ReceivedData = CommandStringTrimmer(ReceivedString);
            clientSock.Close();
        }


        public bool ReqLogin(string email_address, string password)
        {
            SendMessage($"DB_REQ_LOGIN:{email_address};");
            GetMessage();
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
            GetMessage();
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
                    GetMessage();
                    if (ReceivedData.Contains("ACK"))
                    {
                        return true;
                    }
                    else return false;
                }
            }
            return false;
        }

        public bool ChangeBalance(decimal amount)
        {
            return true;
        }

        public DateTime ConvertStringToDateTime(string datetimeString)
        {
            string[] data = new string[3];
            data[0] = datetimeString.Remove(datetimeString.IndexOf('-'));
            data[1] = datetimeString.Substring(datetimeString.IndexOf('-') + 1).Remove(datetimeString.IndexOf('-') - 2);
            data[2] = datetimeString.Substring(datetimeString.IndexOf('-')).Substring(datetimeString.IndexOf('-'));
            DateTime dateTime = new DateTime(Convert.ToInt32(data[0]), Convert.ToInt32(data[1]), Convert.ToInt32(data[2]));
            return dateTime;
        }

        private DateTime ParseBirthDate(string s)
        {
            List<int> indexes = UnderscoreIndexes(s);
            int day = Convert.ToInt32(s.Substring(0, 2));
            int month = Convert.ToInt32(s.Substring(3, 2));
            int year = Convert.ToInt32(s.Substring(6, 4));
            return new DateTime(year, month, day);
        }

        public Address GetAddress(string address)
        {
            List<int> commaindexes = CommaIndexes(address);
            string street = address.Substring(0, address.IndexOf(' '));
            string number = address.Substring(street.Length + 1, commaindexes[0] - street.Length - 1);
            string zipcode = address.Substring(commaindexes[0] + 2, commaindexes[1] - commaindexes[0] - 2);
            string city = address.Substring(commaindexes[1] + 2, commaindexes[2] - commaindexes[1] - 2);
            string country = address.Substring(commaindexes[2] + 2);
            return new Address(street, number, zipcode, city, country);
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

        private string[] ValuesStringTrimmer(string stringToTrim)
        {
            if (!stringToTrim.Contains("%"))
            {
                return new string[] { stringToTrim };
            }
            return stringToTrim.Split('%');
        }

        public void RaiseBalance(User loggedinUser, decimal value)
        {
            SendMessage($"DB_CHANGE_BALANCE:{loggedinUser.UserId}/{value};");
            GetMessage();
            if (ReceivedData.Contains("ACK"))
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
            GetMessage();
            if (ReceivedData.Contains("ACK"))
            {
                return true;
            }
            return false;
        }


        public string[] Req_AllStandId()
        {
            SendMessage("DB_REQ_ALLSTANDID");
            GetMessage();
            if (ReceivedData.Contains("ACK"))
            {
                string allStands = ReceivedData[0];
                return ValuesStringTrimmer(allStands);
            }
            return null;
        }

        public decimal Req_Price(User loggedInUser)
        {
            SendMessage($"DB_REQ_PRICE:{loggedInUser.UserId};");
            GetMessage();
            if (ReceivedData.Contains("ACK"))
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
            GetMessage();
            if (ReceivedData.Contains("ACK"))
            {
                return ReceivedData[1];
            }
            return null;
        }

        /*public string[] ChangeDetails(string[] columNames, string[] newValues)
        {
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
            GetMessage();
        }*/
    }
}
