using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Persons;

namespace Validators
{
    public class CustomerValidator
    {
        public static List<string> ValidateCustomer(Customer customer)
        {
            List<string> errors = new() { };

            if (customer.LastName.Length > 50)
            {
                errors.Add("Last name must be shorter than 50 characters");
            }
            if (customer.LastName.Length == 0)
            {
                errors.Add("Last name required");
            }
            if (customer.FirstName.Length > 50)
            {
                errors.Add("First name must be shorter than 50 characters");
            }
            if (customer.Addresses.Count == 0)
            {
                errors.Add("Required at least 1 address");
            }
            if(!Regex.IsMatch(customer.Email, @"\A[A-Z0-9+_.-]+@[A-Z0-9.-]+\Z"))
            {
                errors.Add("Incorrect email address entered");
            }
            if (!Regex.IsMatch(customer.PhoneNumber, @"^\+?[1-9]\d{1,14}$"))
            {
                errors.Add("Incorrect phone number entered");
            }
            if (customer.Notes.Count == 0)
            {
                errors.Add("Required at least 1 note");
            }

            return errors;
        }
    }
}
