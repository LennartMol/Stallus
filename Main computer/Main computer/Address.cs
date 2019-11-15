using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main_computer
{
    public class Address
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Zipcode { get; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

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
            return $"{Street} {Number}, {Zipcode}, {City}, {Country}"; 
        }
    }
}
