using System;
using System.Collections.Generic;
using System.Linq;
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



            //valid email
            if (!Regex.IsMatch(customer.Email, @"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z"))
            {
                validateCustomerErrors.Add("Incorrect email address entered");
            }
            //valid phone number
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
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
