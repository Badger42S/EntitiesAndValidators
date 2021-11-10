﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRecord;
using Microsoft.Xrm.Sdk;

namespace Persons
{
    class Customer : Person
    {
        public List<Address> Addresses{get;set;}
        public List<string> Notes{get;set;}
        public Money TotalPurchasesAmount{get;set;}
        public string PhoneNumber{get;set;}
        public string Email{get;set;}

        public Customer(string lastName, List<Address> addresses, List<string> notes, 
            Money totalPurchasesAmount, string firstName = "", string phoneNumber = "+55115525632555", 
            string email = "ratata@gmail.com") :base(lastName, firstName)
        {
            Addresses = addresses;
            Notes = notes;
            TotalPurchasesAmount = totalPurchasesAmount;
            PhoneNumber = phoneNumber;
            Email = email;
        }
    }
}
