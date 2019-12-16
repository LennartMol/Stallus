using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stallus
{
    public class Address
    {
        public string Street { get; private set; }
        public string Number { get; private set; }
        public string Zipcode { get ; private set; }
        public string City { get; private set; }
        public string Country { get; private set; }

        public Address(string street, string number, string zipcode, string city, string country)
        {
            if (street != null && number != null && zipcode != null && city != null && country != null)
            {
                Street = street;
                Number = number;
                Zipcode = zipcode;
                City = city;
                Country = country;
            }
            else
            {
                throw new ArgumentNullException("Values cant be null");
            }
        }
        public void ChangeStreet(string changedStreet)
        {
            Street = changedStreet;
        }
        public void ChangeNumber(string changedNumber)
        {
            Number = changedNumber;
        }
        public void ChangeZipcode(string changedZipcode)
        {
            Zipcode = changedZipcode;
        }
        public void ChangeCity(string changedCity)
        {
            City = changedCity;
        }
        public void ChangeCounty(string changedCountry)
        {
            Country = changedCountry;
        }

        public override string ToString()
        {
            return $"{Street}_{Number}_{Zipcode}_{City}_{Country}";
        }

    }
}
