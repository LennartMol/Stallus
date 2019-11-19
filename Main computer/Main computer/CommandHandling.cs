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
        private string prefix = "CommandHandling";
        public string Command { get; private set; }
        public Socket ClientSocket { get; private set; }
        public Database Database { get; private set; }

        public CommandHandling(string command, Socket clientSocket, Database database)
        {
            Command = command;
            ClientSocket = clientSocket;
            Database = database;
        }

        public void DatabaseCommandsHandler(string protocol)
        {
            Database db = new Database();
            string cleanProtocol = protocol.Substring(0, protocol.Length - 1);
            string[] data = CommandStringTrimmer(cleanProtocol);
            if (protocol.StartsWith("INSERT_REGISTRATE"))
            {
                InsertRegistrate(data);
            }
            else if (protocol.StartsWith("REQ_LOGIN"))
            {
                ReqLogin(data);
            }
            else if (protocol.StartsWith("UPDATE_DETAILS"))
            {
                UpdateDetails(data);
            }
        }

        private void SendMessageToSocket(string message, Socket socket)
        {
            socket.Send(Encoding.ASCII.GetBytes(message));
            Console.WriteLine($"Sent: {message}");
        }

        private void InsertRegistrate(string[] data)
        {
            string first_name = data[0];
            string last_name = data[1];
            DateTime date_of_birth = ParseDateTime(data[2]);
            string email_address = data[3];
            string password = data[4].Substring(0, data[4].Length);
            Address address = ParseAddress(data[5]);
            if (Database.EmailAlreadyInUse(email_address))
            {
                string send = $"NACK_INSERT_REGISTRATE:{email_address}";
                SendMessageToSocket(send, ClientSocket);
            }
            else
            {
                if (Database.Registrate(first_name, last_name, date_of_birth, email_address, password, address))
                {
                    string send = $"ACK_INSERT_REGISTRATE:{email_address};";
                    SendMessageToSocket(send, ClientSocket);
                }
                else
                {
                    string send = $"FAIL_INSERT_REGISTRATE:{email_address};";
                    SendMessageToSocket(send, ClientSocket);
                }
            }
        }

        private void ReqLogin(string[] data)
        {
            string username = data[0];
            string userid = Database.RetrieveUserID(username);
            string password = Database.RetrievePassword(username);
            string send = $"ACK_REQ_LOGIN:{userid}/{username}/{password};";
            SendMessageToSocket(send, ClientSocket);
        }

        private void UpdateDetails(string[] data)
        {
            string userid = data[0];
            string[] columns = ValuesStringTrimmer(data[1]);
            string[] newValues = ValuesStringTrimmer(data[2]);
            if (Database.UpdateUserDetails(userid, columns, newValues))
            {
                string send = $"ACK_UPDATE_DETAILS:{userid};";
                SendMessageToSocket(send, ClientSocket);
            }
            else
            {
                string send = $"NACK_UPDATE_DETAILS:{userid};";
                SendMessageToSocket(send, ClientSocket);
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
