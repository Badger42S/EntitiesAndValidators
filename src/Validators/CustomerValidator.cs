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
            List<string> errors = new() { };
            //Customer check
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
            //Adress check
            if (customer.Addresses.Any(adress => adress.AddressLine.Length == 0))
            {
                errors.Add("Address line required");
            }
            if (customer.Addresses.Any(adress => adress.AddressLine.Length > 100))
            {
                errors.Add("Address line must be shorter than 100 characters");
            }
            if (customer.Addresses.Any(adress => adress.AddressLine2.Length > 100))
            {
                errors.Add("Address line2 must be shorter than 100 characters");
            }
            if (customer.Addresses.Any(adress => adress.AddressType != Address.AddressTypeEnum.Billing ||
                adress.AddressType != Address.AddressTypeEnum.Shipping))
            {
                errors.Add("Incorrect address type entered");
            }
            if (customer.Addresses.Any(adress => adress.City.Length == 0))
            {
                errors.Add("City required");
            }
            if (customer.Addresses.Any(adress => adress.City.Length > 50))
            {
                errors.Add("The name of the city must be shorter than 50 characters");
            }
            if (customer.Addresses.Any(adress => adress.PostalCode.Length > 6))
            {
                errors.Add("Postal code must be shorter than 6 characters");
            }
            if (customer.Addresses.Any(adress => adress.State.Length == 0))
            {
                errors.Add("State required");
            }
            if (customer.Addresses.Any(adress => adress.State.Length > 20))
            {
                errors.Add("The name of the state should be shorter than 20 characters");
            }
            if (customer.Addresses.Any(adress => adress.Country != "Canada" ||
                adress.Country != "United States"))
            {
                errors.Add("Incorrect country entered. It should be Canada or United States");
            }

            return errors;
        }
    }
}
