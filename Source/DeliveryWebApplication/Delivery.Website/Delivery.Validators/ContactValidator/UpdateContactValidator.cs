using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class UpdateContactValidator : BaseValidator<UpdateContactModel, Contact>
    {
        public UpdateContactValidator(IContactService contactService) : base(contactService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(contact => $"Contact with id '{contact.Id}' doesn't exist");

            RuleFor(x => x)
                .SetValidator(new ContactValidator(contactService));
        }
    }
}