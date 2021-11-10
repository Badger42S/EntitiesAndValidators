using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRecord;

namespace Persons
{
    public class Customer : Person
    {
        public List<Address> Addresses{get;set;}
        public List<string> Notes{get;set;}
        public double? TotalPurchasesAmount{get;set;}
        public string PhoneNumber{get;set;}
        public string Email{get;set;}

        public Customer(string lastName, List<Address> addresses, List<string> notes,
            double? totalPurchasesAmount, string firstName = "", string phoneNumber = "", 
            string email = "") :base(lastName, firstName)
        {
            Addresses = addresses;
            Notes = notes;
            TotalPurchasesAmount = totalPurchasesAmount;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
