using Persons;
using FluentValidation;

namespace Validators
{
    public class CustomerValidator: AbstractValidator<Customer>
    {
        public CustomerValidator()
        {
            //Customer check
            RuleFor(customer => customer.LastName).NotEmpty().WithMessage("Last name required");
            RuleFor(customer => customer.LastName).MaximumLength(50).WithMessage("Last name must be shorter than 50 characters");
            RuleFor(customer => customer.FirstName).MaximumLength(50).WithMessage("First name must be shorter than 50 characters");
            RuleFor(customer => customer.Addresses).NotEmpty().WithMessage("Required at least 1 address");
            RuleForEach(customer => customer.Addresses).SetValidator(new AddressValidator());
            RuleFor(customer => customer.Email).Matches(@"^[a-z0-9+_.-]+@[a-z0-9.-]+\.[a-z]{1,5}$").
                When(customer => customer.Email.Length != 0).WithMessage("Incorrect email address entered");
            RuleFor(customer => customer.PhoneNumber).Matches(@"^\+?[1-9]\d{1,14}$").
                When(customer => customer.PhoneNumber.Length != 0).WithMessage("Incorrect phone number entered");
            RuleFor(customer => customer.Notes).NotEmpty().WithMessage("Required at least 1 note");
        }
    }
}
