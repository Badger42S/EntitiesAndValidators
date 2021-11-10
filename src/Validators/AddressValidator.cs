using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRecord;

namespace Validators
{
    class AddressValidator
    {
        public static List<string> Validate(Address address)
        {
            List<string> validateAddressErrors = new() { };

            //AddressLine required
            if (address.AddressLine.Length == 0)
            {
                validateAddressErrors.Add("Address line required");
            }
            //AddressLine lenght
            if (address.AddressLine.Length > 100)
            {
                validateAddressErrors.Add("Address line must be shorter than 100 characters");
            }
            //AddressLine2 lenght
            if (address.AddressLine2.Length > 100)
            {
                validateAddressErrors.Add("Address line2 must be shorter than 100 characters");
            }
            if (address.AddressType != Address.AddressTypeEnum.Billing ||
                address.AddressType != Address.AddressTypeEnum.Shipping)
            {
                validateAddressErrors.Add("Incorrect address type entered");
            }
            //City required
            if (address.City.Length == 0)
            {
                validateAddressErrors.Add("City required");
            }
            //City lenght
            if (address.City.Length > 50)
            {
                validateAddressErrors.Add("The name of the city must be shorter than 50 characters");
            }
            //PostalCode lenght
            if (address.PostalCode.Length > 6)
            {
                validateAddressErrors.Add("Postal code must be shorter than 6 characters");
            }
            //PostalCode required
            if (address.State.Length == 0)
            {
                validateAddressErrors.Add("State required");
            }
            //State lenght
            if (address.State.Length > 20)
            {
                validateAddressErrors.Add("The name of the state should be shorter than 20 characters");
            }
            //entered country
            if (address.Country != "Canada" ||
                address.Country != "United States")
            {
                validateAddressErrors.Add("Incorrect country entered. It should be Canada or United States");
            }

            return validateAddressErrors;
        }
    }
}
