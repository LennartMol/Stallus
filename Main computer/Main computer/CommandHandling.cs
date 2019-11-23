using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;

namespace Main_computer
{
    public class CommandHandling
    {
        public string Command { get; private set; }
        public string[] Data { get; private set; }
        public Socket ClientSocket { get; private set; }
        public Database Database { get; private set; }
        public SerialMessenger SerialMessenger { get; private set; }

        public CommandHandling(string command, Socket clientSocket)
        {
            Command = command;
            ClientSocket = clientSocket;
            Database = new Database();
            Data = CommandStringTrimmer(command);
        }

        public CommandHandling(string command, SerialMessenger messenger)
        {
            Command = command;
            SerialMessenger = messenger;
            Database = new Database();
            Data = CommandStringTrimmer(command);
        }

        public void DatabaseCommandsHandler()
        {
            if (Command.StartsWith("DB_INSERT_REGISTRATE"))
            {
                InsertRegistrate();
            }
            else if (Command.StartsWith("DB_REQ_LOGIN"))
            {
                ReqLogin();
            }
            else if (Command.StartsWith("DB_REQ_USER"))
            {
                ReqUser();
            }
            else if (Command.StartsWith("DB_REQ_BALANCE"))
            {
                ReqBalance();
            }
            else if (Command.StartsWith("DB_UPDATE_DETAILS"))
            {
                UpdateDetails();
            }
            else if (Command.StartsWith("DB_CHANGE_BALANCE"))
            {
                ChangeBalance();
            }
            else if (Command.StartsWith("DB_BIKE_LOCKED"))
            {
                BikeLocked();
            }
            else if (Command.StartsWith("DB_USER_UNLOCKED"))
            {
                BikeStandPaid();
            }
        }

        public void ArduinoCommandsHandler()
        {

        }

        private void SendMessageToSocket(string message)
        {
            ClientSocket.Send(Encoding.ASCII.GetBytes(message));
            Console.WriteLine($"Sent: {message}");
        }

        private void SendMessageToSerialPort(string message)
        {
            SerialMessenger.SendMessage(message);
            Console.WriteLine($"Sent: {message}");
        }

        private void InsertRegistrate()
        {
            string first_name = Data[0];
            string last_name = Data[1];
            DateTime date_of_birth = ParseDateTime(Data[2]);
            string email_address = Data[3];
            string password = Data[4].Substring(0, Data[4].Length);
            Address address = ParseAddress(Data[5]);
            if (Database.EmailAlreadyInUse(email_address))
            {
                string send = $"NACK_INSERT_REGISTRATE:{email_address};";
                SendMessageToSocket(send);
            }
            else
            {
                if (Database.Registrate(first_name, last_name, date_of_birth, email_address, password, address))
                {
                    string send = $"ACK_INSERT_REGISTRATE:{email_address};";
                    SendMessageToSocket(send);
                }
                else
                {
                    string send = $"FAIL_INSERT_REGISTRATE:{email_address};";
                    SendMessageToSocket(send);
                }
            }
        }

        private void ReqLogin()
        {
            string username = Data[0];
            string userid = Database.RetrieveUserID(username);
            string password = Database.RetrievePassword(username);
            string send = $"ACK_REQ_LOGIN:{userid}/{username}/{password};";
            SendMessageToSocket(send);
        }

        private void ReqUser()
        {
            string userid = Data[0];
            User user = Database.GetUser(userid);
            if (user != null)
            {
                string first_name = user.FirstName;
                string last_name = user.LastName;
                string date_of_birth = user.DateOfBirth.ToString("dd_MM_yyyy");
                string email_address = user.Email;
                string password = user.Password;
                string address = $"{user.Address.Street}_{user.Address.Number}_{user.Address.Zipcode}_{user.Address.City}_{user.Address.Country}";
                string balance = user.Balance.ToString();
                string send = $"ACK_REQ_USER:{userid}/{first_name}/{last_name}/{date_of_birth}/{email_address}/{password}/{address}/{balance};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_REQ_USER:{userid};";
                SendMessageToSocket(send);
            }
        }

        private void ReqBalance()
        {
            string userid = Data[0];
            decimal balance = Database.GetUserBalance(userid);
            string send = $"ACK_REQ_USER:{userid}/{balance};";
            SendMessageToSocket(send);
        }

        private void UpdateDetails()
        {
            string userid = Data[0];
            string[] columns = ValuesStringTrimmer(Data[1]);
            string[] newValues = ValuesStringTrimmer(Data[2]);
            if (Database.UpdateUserDetails(userid, columns, newValues))
            {
                string send = $"ACK_UPDATE_DETAILS:{userid};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_UPDATE_DETAILS:{userid};";
                SendMessageToSocket(send);
            }
        }

        private void ChangeBalance()
        {
            string userid = Data[0];
            string value = Data[1];
            decimal addedValue = Convert.ToDecimal(value);
            if (Database.ChangeBalance(userid, addedValue))
            {
                decimal newBalance = Database.GetUserBalance(userid);
                string send = $"ACK_CHANGE_BALANCE:{userid}/{newBalance};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_CHANGE_BALANCE:{userid};";
                SendMessageToSocket(send);
            }
        }

        private void BikeLocked()
        {
            string stand_id = Data[0];
            Verification ver = new Verification();
            string verification_key = ver.GetNewKey();
            if (Database.LockBikeStand(stand_id, verification_key))
            {
                string send = $"ACK_BIKE_LOCKED:{stand_id};";
                SendMessageToSerialPort(send);
            }
            else
            {
                string send = $"NACK_BIKE_LOCKED:{stand_id};";
                SendMessageToSerialPort(send);
            }
        }

        private void BikeStandPaid()
        {
            string verification_key = Data[0];
            string userid = Data[1];
            string stand_id = Database.GetStandID_linkedToKey(verification_key);
            if (stand_id != null)
            {
                if (Database.UserPaidForBikeStand(verification_key, userid))
                {

                }
            }
        }

        private string[] CommandStringTrimmer(string stringToTrim)
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

        private DateTime ParseDateTime(string date)
        {
            List<int> divisor_indexes = GetDivisorIndexes(date);

            int year = Convert.ToInt32(date.Substring(divisor_indexes[1] + 1));
            int month = Convert.ToInt32(date.Substring(divisor_indexes[0] + 1, divisor_indexes[1] - divisor_indexes[0] - 1));
            int day = Convert.ToInt32(date.Substring(0, divisor_indexes[0]));
            return new DateTime(year, month, day);
        }

        private Address ParseAddress(string address)
        {
            List<int> divisor_indexes = GetDivisorIndexes(address);
            string street = address.Substring(0, divisor_indexes[0]);
            string number = address.Substring(divisor_indexes[0] + 1, divisor_indexes[1] - divisor_indexes[0] - 1);
            string zipcode = address.Substring(divisor_indexes[1] + 1, divisor_indexes[2] - divisor_indexes[1] - 1);
            string city = address.Substring(divisor_indexes[2] + 1, divisor_indexes[3] - divisor_indexes[2] - 1);
            string country = address.Substring(divisor_indexes[3] + 1);
            return new Address(street, number, zipcode, city, country);
        }

        private List<int> GetDivisorIndexes(string data)
        {
            List<int> divisor_indexes = new List<int>();
            char[] data_charArray = data.ToCharArray();
            for (int i = 0; i < data.Length; i++)
            {
                if (data_charArray[i] == '_')
                {
                    divisor_indexes.Add(i);
                }
            }
            return divisor_indexes;
        }
    }
}
