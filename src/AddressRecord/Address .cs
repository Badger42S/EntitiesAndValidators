using System;

namespace AddressRecord
{
    public class Address
    {
        public enum AddressType
        {
            Shipping,
            Billing
        }
        public Address(string addressLine, AddressType addressType, string city, 
            string postalCode, string state, string country, string addressLine2 = "")
        {

        }
    }
}
