using Delivery.BL;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class DeleteUserValidator : BaseValidator<DeleteUserModel, User>
    {
        public DeleteUserValidator(IUserService userService) : base(userService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(user => $"User with id '{user.Id}' doesn't exist");
        }
    }
}
