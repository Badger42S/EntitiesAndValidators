using System;
using Xunit;
using AddressRecord;
using Validators;
using System.Collections.Generic;
using System.Linq;

namespace Validators.Tests
{
    public class AddressValidatorTest
    {
        [Fact]
        public void ShouldBeValidAddress()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");
            Assert.Empty(AddressValidator.Validate(address));
            var addressNoLine2 = new Address("addressLine", Address.AddressTypeEnum.Shipping, "Toronto", "M9M", "Ontario", "Canada");
            Assert.Empty(AddressValidator.Validate(addressNoLine2));
        }
        [Fact]
        public void ShouldBeAddressLineRequired()
        {
            var address = new Address("", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2");;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Address line required" }, errorString);
        }
        [Fact]
        public void ShouldBeAddressLineLength()
        {
            var wrongAddressLine =string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var address = new Address(wrongAddressLine, Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", "addressLine2"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Address line must be shorter than 100 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeAddressLine2Length()
        {
            var wrongAddressLine = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", "Canada", wrongAddressLine); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Address line2 must be shorter than 100 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeCityRequired()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "", "M9M", "Ontario", "Canada", "addressLine2"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "City required" }, errorString);
        }
        [Fact]
        public void ShouldBeCityLength()
        {
            var wrongCity = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, wrongCity, "M9M", "Ontario", "Canada", "addressLine"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "The name of the city must be shorter than 50 characters" }, errorString);
        }
        [Fact]
        public void ShouldBePostalCodeRequired()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "", "Ontario", "Canada", "addressLine2"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Postal code required" }, errorString);
        }
        [Fact]
        public void ShouldBePostalCodeLength()
        {
            var wrongPostalCode = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", wrongPostalCode, "Ontario", "Canada", "addressLine"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Postal code must be shorter than 6 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeStateRequired()
        {
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "", "Canada", "addressLine2"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "State required" }, errorString);
        }
        [Fact]
        public void ShouldBeStateLength()
        {
            var wrongState = string.Join("", Enumerable.Repeat("C#", 101).ToArray());
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", wrongState, "Canada", "addressLine"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "The name of the state should be shorter than 20 characters" }, errorString);
        }
        [Fact]
        public void ShouldBeCountry()
        {
            var wrongCountry = "Russia";
            var address = new Address("addressLine", Address.AddressTypeEnum.Billing, "Toronto", "M9M", "Ontario", wrongCountry, "addressLine"); ;
            var errorString = AddressValidator.Validate(address);
            Assert.Equal(new List<string> { "Incorrect country entered. It should be Canada or United States" }, errorString);
        }
    }
}
