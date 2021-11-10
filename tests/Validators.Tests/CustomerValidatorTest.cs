using Xunit;
using AddressRecord;
using Persons;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Validators.Tests
{
    public class CustomerValidatorTest
    {
        CustomerValidator customerValidator = new CustomerValidator();
        [Fact]
        public void ShouldBeValidCustomer()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            Assert.True(result.IsValid);

            customer.TotalPurchasesAmount = null;
            customer.FirstName = "";
            customer.PhoneNumber = "";
            customer.Email = "";
            result = customerValidator.Validate(customer);
            Assert.True(result.IsValid);
        }
        [Fact]
        public void ShouldBeLastNameRequired()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("", addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Last name required" }, errorString);
        }
        [Fact]
        public void ShouldBeLastNameLength()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var wrongLastName = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var customer = new Customer(wrongLastName, addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Last name must be shorter than 50 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeFirstNameLength()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var wrongFirstName = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var customer = new Customer("Pol", addressList, notes, 47, wrongFirstName, "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "First name must be shorter than 50 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeAdressesRequired()
        {
            var addressList = new List<Address> { };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Required at least 1 address" }, errorString);
        }
        [Fact]
        public void ShouldBeEmail()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "+900000000000000", "wheregolodune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Incorrect email address entered" }, errorString);
        }
        [Fact]
        public void ShouldBePhoneNumber()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "*900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Incorrect phone number entered" }, errorString);
        }
        [Fact]
        public void ShouldBeNotesRequired()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> {};
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Required at least 1 note" }, errorString);
        }
        [Fact]
        public void ShouldBeAddressValidator()
        {
            var address = new Address("", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            var addressList = new List<Address> { address };
            var notes = new List<string> { "eat spice" };
            var customer = new Customer("Pol", addressList, notes, 47, "Atr", "+900000000000000", "where@golo.dune");
            ValidationResult result = customerValidator.Validate(customer);
            var errorString = new List<string> { result.ToString() };
            Assert.Equal(new List<string> { "Address line required" }, errorString);
        }
    }
}
