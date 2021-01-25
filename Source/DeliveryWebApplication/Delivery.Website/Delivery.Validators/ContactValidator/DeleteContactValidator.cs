using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class DeleteContactValidator : BaseValidator<DeleteContactModel, Contact>
    {
        public DeleteContactValidator(IContactService contactService) : base(contactService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(contact => $"Contact with id '{contact.Id}' doesn't exist");
        }
    }
}
