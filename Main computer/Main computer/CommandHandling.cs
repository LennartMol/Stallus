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
        private LocalSafe localSafe;

        public CommandHandling(string command, Socket clientSocket)
        {
            Command = command;
            ClientSocket = clientSocket;
            Database = new Database();
            Data = CommandStringTrimmer(command);
            localSafe = new LocalSafe();
        }

        public CommandHandling(string command, SerialMessenger messenger)
        {
            Command = command;
            SerialMessenger = messenger;
            Database = new Database();
            Data = CommandStringTrimmer(command);
            localSafe = new LocalSafe();
        }

        public void DatabaseCommandsHandler()
        {
            if (Command.StartsWith("DB_CHECK"))
            {
                Check();
            }
            else if (Command.StartsWith("DB_INSERT_REGISTRATE"))
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
            else if (Command.StartsWith("DB_BIKE_AUTOLOCKED"))
            {
                BikeAutoLocked();
            }
            else if (Command.StartsWith("DB_LOCK_BIKE"))
            {
                LockBike();
            }
            else if (Command.StartsWith("DB_STAND_DISCONNECTED"))
            {
                ProcessLockProcedure();
            }
            else if (Command.StartsWith("DB_REQ_PRICE"))
            {
                ReqPrice();
            }
            else if (Command.StartsWith("DB_USER_UNLOCKED"))
            {
                BikeStandPaid();
            }
            else if (Command.StartsWith("DB_REQ_ALLSTANDID"))
            {
                ReqAllStands();
            }
            else if (Command.StartsWith("DB_REQ_VERIFICATIONKEY"))
            {
                ReqVerificationKey();
            }
            else if (Command.StartsWith("DB_REQ_EXISTING_SESSION_USER"))
            {
                CheckForExistingSessionUser();
            }
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

        private void Check()
        {
            string send = "ACK;";
            SendMessageToSocket(send);
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
            string email_address = Data[0];
            string userid = Database.RetrieveUserID(email_address);
            string password = Database.RetrievePassword(email_address);
            string send = $"ACK_REQ_LOGIN:{userid}/{email_address}/{password};";
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
            string[] cleanValues = GetCleanValues(columns, newValues);
            if (Database.UpdateUserDetails(userid, columns, cleanValues))
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

        private string[] GetCleanValues(string[] columns, string[] newValues)
        {
            string[] cleanValues = new string[columns.Length];
            for (int i = 0; i < columns.Length; i++)
            {
                if (columns[i] == "date_of_birth")
                {
                    cleanValues[i] = ParseDateTime(newValues[i]).ToString();
                }
                else if (columns[i] == "physical_address")
                {
                    cleanValues[i] = ParseAddress(newValues[i]).ToString();
                }
                else
                {
                    cleanValues[i] = newValues[i];
                }
            }
            return cleanValues;
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

        private void BikeAutoLocked()
        {
            string stand_id = Data[0];
            List<LockProcedure> instances = localSafe.Load();
            Verification ver = new Verification();
            string verification_key = ver.GetNewKey();
            if (Database.AutoLockBikeStand(stand_id, verification_key))
            {
                string send = $"ACK_BIKE_LOCKED:{stand_id};";
                SendMessageToSerialPort(send);
            }
            else
            {
                string send = $"NACK_BIKE_LOCKED:{stand_id};";
                SendMessageToSerialPort(send);
            }
            instances.Add(new LockProcedure(stand_id, verification_key));
            localSafe.Save(instances);
        }

        private void LockBike()
        {
            string stand_id = Data[0];
            string userid = Data[1];
            List<LockProcedure> instances = localSafe.Load();
            for (int i = instances.Count - 1; i >= 0; i--)
            {
                if (instances[i].IsLocked == false && instances[i].StandID == stand_id)
                {
                    instances[i].UserID = userid;
                    Verification ver = new Verification();
                    instances[i].Key = ver.GetNewKey();
                    if (Database.LockBikeStand(instances[i]))
                    {
                        instances[i].IsLocked = true;
                        localSafe.Save(instances);
                        string send = $"ACK_BIKE_LOCKED:{stand_id}/{userid};";
                        SendMessageToSocket(send);
                        break;
                    }
                    else
                    {
                        string send = $"NACK_BIKE_LOCKED:{stand_id}/{userid};";
                        SendMessageToSocket(send);
                        break;
                    }
                }
            }
        }

        private void ProcessLockProcedure()
        {
            string stand_id = Data[0];
            List<LockProcedure> instances = localSafe.Load();
            List<string> standIDsToSkip = new List<string>();
            bool notFound = true;
            for (int i = instances.Count - 1; i >= 0; i--)
            {
                if (instances[i].StandID == stand_id && instances[i].IsLocked && !CheckIfStandAlreadyLocked(standIDsToSkip, instances[i].StandID))
                {
                    standIDsToSkip.Add(instances[i].StandID);
                    notFound = false;
                    string send = "lockBicycleStand";
                    SendMessageToSerialPort(send);
                }
            }
            if (notFound)
            {
                LockProcedure procedure = new LockProcedure(stand_id, LockProcedure.StartingWith.StandID);
                instances.Add(procedure);
            }
            localSafe.Save(instances);
        }

        private bool CheckIfStandAlreadyLocked(List<string> stands, string stand)
        {
            foreach (string s in stands)
            {
                if (s == stand)
                {
                    return true;
                }
            }
            return false;
        }

        private void ReqPrice()
        {
            string userid = Data[0];
            string verification_key = Database.GetVerificationKey(userid);
            double price = Database.GetPrice(verification_key);
            if (verification_key != null && price != 0)
            {
                string send = $"ACK_REQ_PRICE:{userid}/{price.ToString("#.##")};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_REQ_PRICE:{userid};";
                SendMessageToSocket(send);
            }
        }

        private void BikeStandPaid()
        {
            string verification_key = Data[0];
            string stand_id = Database.GetStandID_linkedToKey(verification_key);
            List<LockProcedure> instances = localSafe.Load();
            if (stand_id != null)
            {
                if (Database.UserPaidForBikeStand(verification_key))
                {
                    string send = $"unlockBicycleStand";
                    SendMessageToSerialPort(send);
                    localSafe.Save(ClearAllInstancesForStand(instances, stand_id));
                }
            }
        }

        private List<LockProcedure> ClearAllInstancesForStand(List<LockProcedure> instances, string standId_ToDelete)
        {
            foreach (LockProcedure lp in instances.ToList())
            {
                if (lp.StandID == standId_ToDelete)
                {
                    instances.Remove(lp);
                }
            }
            return instances;
        }

        private void ReqAllStands()
        {
            List<string> stands = Database.LoadStandIDs();
            if (stands != null)
            {
                string send = $"ACK_REQ_ALLSTANDID:{ListToString(stands)};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_REQ_ALLSTANDID:;";
                SendMessageToSocket(send);
            }
        }

        private void ReqVerificationKey()
        {
            string userid = Data[0];
            string verification_key = Database.GetVerificationKey(userid);
            if (verification_key != null)
            {
                uint uid = Convert.ToUInt32(userid);
                uint ver = Convert.ToUInt32(verification_key);
                string send = $"ACK_REQ_VERIFICATIONKEY:{(uid <<16) | ver};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_REQ_VERIFICATIONKEY:{userid};";
                SendMessageToSocket(send);
            }
        }

        private void CheckForExistingSessionUser()
        {
            string userid = Data[0];
            List<LockProcedure> instances = localSafe.Load();
            LockProcedure found = null;
            foreach (LockProcedure lp in instances)
            {
                if (lp.UserID == userid)
                {
                    found = lp;
                    break;
                }
            }
            if (found != null)
            {
                string send = $"ACK_REQ_EXSISTING_SESSION_USER:{userid}/{found.StandID}/{found.DateTime.ToString("hh_mm_ss_dd_MM_yyyy")};";
                SendMessageToSocket(send);
            }
            else
            {
                string send = $"NACK_REQ_EXISTING_SESSION_USER:{userid};";
                SendMessageToSocket(send);
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

        private string ListToString(List<string> values)
        {
            string s = "";
            for (int i = 0; i < values.Count; i++)
            {
                if (i + 1 == values.Count)
                {
                    s += values[i];
                }
                else
                {
                    s += values[i] + "%";
                }
            }
            return s;
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
