using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AddressRecord;
using FluentValidation;

namespace Validators
{
    public class AddressValidator: AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(adress => adress.AddressLine).NotEmpty().WithMessage("Address line required");
            RuleFor(adress => adress.AddressLine).MaximumLength(100).WithMessage("Address line must be shorter than 100 characters");
            RuleFor(adress => adress.AddressLine2).MaximumLength(100).WithMessage("Address line2 must be shorter than 100 characters");
            RuleFor(adress => adress.AddressType).IsInEnum().WithMessage("Incorrect address type entered");
            RuleFor(adress => adress.City).NotEmpty().WithMessage("City required");
            RuleFor(adress => adress.City).MaximumLength(50).WithMessage("The name of the city must be shorter than 50 characters");
            RuleFor(adress => adress.PostalCode).NotEmpty().WithMessage("Postal code required");
            RuleFor(adress => adress.PostalCode).MaximumLength(6).WithMessage("Postal code must be shorter than 6 characters");
            RuleFor(adress => adress.State).NotEmpty().WithMessage("State required");
            RuleFor(adress => adress.State).MaximumLength(20).WithMessage("The name of the state should be shorter than 20 characters");
            RuleFor(adress => adress.Country).Matches(@"Canada|(United States)").WithMessage("Incorrect country entered. It should be Canada or United States");
        }
    }
}
