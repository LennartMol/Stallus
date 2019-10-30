using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class Customer: ICustomer
    {
        private string firstName;
        private string lastName;
        private string password;
        private DateTime dateOfBirth;
        private Address address;
        //int customerId;
        private string email;
        private decimal balance;


        public string FirstName { get => firstName; private set => firstName = value; }
        public string LastName { get => lastName; private set => lastName = value; }
        public DateTime DateOfBirth { get => dateOfBirth; private set => dateOfBirth = value; }
        //public int CustomerId { get => customerId; private set => customerId = value; }
        public string Email { get => email; private set => email = value; }
        public decimal Balance { get => balance; private set => balance = value; }
        public string Password { get => password; private set => password = value; }
        public Address Address { get => address; set => address = value; }

        public Customer(string firstName, string lastName, string password, DateTime dateOfBirth, /*int customerId,*/ string email, decimal balance, Address address)
        {
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Address = address;
            DateOfBirth = dateOfBirth;
            //CustomerId = customerId;
            Email = email;
            Balance = balance;
        }

        public decimal RaiseBalance(decimal raiseValue)
        {
            if (raiseValue > 0)
            {
                return Balance = Balance + raiseValue;
            }
            else return Balance;
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
