using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class Customer
    {
        string name;
        DateTime dateOfBirth;
        int customerId;
        string email;
        decimal balance;

        public string Name { get => name; private set => name = value; }
        public DateTime DateOfBirth { get => dateOfBirth; private set => dateOfBirth = value; }
        public int CustomerId { get => customerId; private set => customerId = value; }
        public string Email { get => email; private set => email = value; }
        public decimal Balance { get => balance; private set => balance = value; }

        public Customer(string name, DateTime dateOfBirth, int customerId, string email, decimal balance)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            CustomerId = customerId;
            Email = email;
            Balance = balance;
        }

        public override string ToString()
        {
            return $"Customer id: {CustomerId}" +
                   $"Name: {Name} \n" +
                   $"Birthday: {DateOfBirth}" +
                   $"Email: {Email}" +
                   $"Balance: {Balance}";
        }

    }
}
