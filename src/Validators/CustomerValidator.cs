using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Persons;
using AddressRecord;

namespace Validators
{
    public class CustomerValidator
    {
        public static List<string> Validate(Customer customer)
        {
            List<string> validateCustomerErrors = new() { };
            //Customer check
            //LastName lenght
            if (customer.LastName.Length > 50)
            {
                validateCustomerErrors.Add("Last name must be shorter than 50 characters");
            }
            //LastName required
            if (customer.LastName.Length == 0)
            {
                validateCustomerErrors.Add("Last name required");
            }
            //FirstName lenght
            if (customer.FirstName.Length > 50)
            {
                validateCustomerErrors.Add("First name must be shorter than 50 characters");
            }
            //Adresses count
            if (customer.Addresses.Count == 0)
            {
                validateCustomerErrors.Add("Required at least 1 address");
            }
            //Adress list check
            foreach(var address in customer.Addresses)
            {
                validateCustomerErrors.AddRange(AddressValidator.Validate(address));
            }
            //valid email
            if (customer.Email.Length !=0 && 
                !Regex.IsMatch(customer.Email, @"^[a-z0-9+_.-]+@[a-z0-9.-]+\.[a-z]{1,5}$", RegexOptions.IgnoreCase))
            {
                validateCustomerErrors.Add("Incorrect email address entered");
            }
            //valid phone number
            if (customer.PhoneNumber.Length != 0 && !Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
            {
                validateCustomerErrors.Add("Incorrect phone number entered");
            }
            //Notes count
            if (customer.Notes.Count == 0)
            {
                validateCustomerErrors.Add("Required at least 1 note");
            }

            return validateCustomerErrors;
        }
    }
}
