using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class Address
    {
        string street;
        string number;
        string zipcode;
        string city;
        string country;

        public string Street { get => street; set => street = value; }
        public string Number { get => number; set => number = value; }
        public string Zipcode { get => zipcode; set => zipcode = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }

        public Address(string street, string number, string zipcode, string city, string country)
        {
            Street = street;
            Number = number;
            Zipcode = zipcode;
            City = city;
            Country = country;

        }

        public override string ToString()
        {
            return $"Address: {Street}, {Number}, {Zipcode}, {City}, {Country}";
        }
    }
}
