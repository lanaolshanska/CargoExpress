using Delivery.BL;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class UpdateUserValidator : BaseValidator<UpdateUserModel, User>
    {
        public UpdateUserValidator(IUserService userService) : base(userService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(user => $"User with id '{user.Id}' doesn't exist");

            RuleFor(x => x)
                .SetValidator(new UserValidator(userService));
        }
    }
}