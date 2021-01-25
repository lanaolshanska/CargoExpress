using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Validators
{
    public class ContactValidator : BaseValidator<ContactModel, Contact>
    {
        public ContactValidator(IContactService contactService) : base(contactService)
        {
            RuleFor(x => x.FirstName)
                   .NotEmpty().WithMessage("Enter first name")
                   .MaximumLength(CustomMaxLength).WithMessage($"First name must not exceed {CustomMaxLength} characters")
                   .Matches(RegExpForChars).WithMessage("First name must contain only letters");

            RuleFor(x => x.LastName)
                   .NotEmpty().WithMessage("Enter last name")
                   .MaximumLength(CustomMaxLength).WithMessage($"Last name must not exceed {CustomMaxLength} characters")
                   .Matches(RegExpForChars).WithMessage("Last name must contain only letters");

            RuleFor(x => x.Phone)
                   .Matches(RegExpForDigits).WithMessage("Phone must contain only digits")
                   .MaximumLength(CustomMaxLength).WithMessage($"Phone must not exceed {CustomMaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Address)
                   .MaximumLength(MaxLength).WithMessage($"Address must not exceed {MaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.Email)
                   .EmailAddress().WithMessage("Not valid email address")
                   .MaximumLength(MaxLength).WithMessage($"Email must not exceed {MaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Email));
        }
    }
}