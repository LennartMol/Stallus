using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class Customer
    {
        private string name;
        private string password;
        private DateTime dateOfBirth;
        private Address address;
        //int customerId;
        private string email;
        private decimal balance;
        

        public string Name { get => name; private set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; private set => dateOfBirth = value; }
        //public int CustomerId { get => customerId; private set => customerId = value; }
        public string Email { get => email; private set => email = value; }
        public decimal Balance { get => balance; private set => balance = value; }
        public string Password { get => password; private set => password = value; }
        public Address Address { get => address; set => address = value; }

        public Customer(string name, string password, DateTime dateOfBirth, /*int customerId,*/ string email, decimal balance, Address address)
        {
            Name = name;
            Password = password;
            Address = address;
            DateOfBirth = dateOfBirth;
            //CustomerId = customerId;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Name: {Name} \n" +
                   $"Birthday: {DateOfBirth}" +
                   $"Email: {Email}" +
                   $"Balance: {Balance}";
        }

    }
}
