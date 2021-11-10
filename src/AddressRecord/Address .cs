using System;

namespace AddressRecord
{
    public class Address
    {
        public enum AddressTypeEnum
        {
            Shipping =0 ,
            Billing = 1
        }
        public string AddressLine { get; set; }
        public string AddressLine2 { get; set; }
        public AddressTypeEnum AddressType { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Address(string addressLine, AddressTypeEnum addressType, string city, 
            string postalCode, string state, string country, string addressLine2 = "")
        {
            AddressLine = addressLine;
            AddressLine2 = addressLine2;
            AddressType = addressType;
            City = city;
            PostalCode = postalCode;
            State = state;
            Country = country;
        }
    }
}
