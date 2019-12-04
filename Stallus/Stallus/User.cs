using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class User
    {
        private string userId;
        private string firstName;
        private string lastName;
        private string password;
        private DateTime dateOfBirth;
        private Address address;
        private string email;
        private decimal balance;


        public string FirstName
        {
            get { return firstName; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    firstName = value;
                }
            }
        }
        public string LastName
        {
            get { return lastName; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    lastName = value;
                }
            }
        }

        public DateTime DateOfBirth
        {
            get { return dateOfBirth; }
            private set
            {
                if (value != null)
                {
                    dateOfBirth = value;
                }
            }
        }

        public string Email
        {
            get { return email; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    email = value;
                }
            }
        }

        public decimal Balance { get => balance; private set => balance = value; }

        public string Password
        {
            get { return password; }
            private set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    password = value;
                }
            }
        }
        public Address Address
        {
            get { return address; }
            set
            {
                if (value != null)
                {
                    address = value;
                }
            }
        }

        public string UserId
        {
            get { return userId; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                {
                    userId = value;
                }
            }
        }

        public User(string userId, string firstName, string lastName, DateTime dateOfBirth, string email, string password, Address address, decimal balance)
        {
            if (firstName != null || LastName != null || password != null || address != null || email != null)
            {
                UserId = userId;
                FirstName = firstName;
                LastName = lastName;
                Password = password;
                DateOfBirth = dateOfBirth;
                Address = address;
                Email = email;
                Balance = balance;
            }
            else
            {
                throw new ArgumentNullException("Values can't be null");
            }
        }

        /// <summary>
        /// Login user info
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <param name="balance"></param>
        public User(string firstName, string lastName, string password, DateTime dateOfBirth, string email, decimal balance, Address address)
        {
            if (firstName != null || LastName != null || password != null || address != null || email != null)
            {
                FirstName = firstName;
                LastName = lastName;
                Password = password;
                DateOfBirth = dateOfBirth;
                Address = address;
                Email = email;
                Balance = balance;
            }
            else
            {
                throw new ArgumentNullException("Values can't be null");
            }
        }

        public void RaiseBalance(decimal newBalance)
        {
            Balance = newBalance;
        }

        public override string ToString()
        {
            return $"Name: {FirstName} {LastName} \n" +
                   $"Birthday: {DateOfBirth.ToShortDateString()} \n" +
                   $"Email: {Email} \n" +
                   $"Balance: {Balance}";
        }

    }
}
