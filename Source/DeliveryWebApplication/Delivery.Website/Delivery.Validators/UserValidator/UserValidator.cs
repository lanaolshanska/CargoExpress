using Delivery.BL;
using Delivery.Models;
using FluentValidation;
using System.Threading.Tasks;

namespace Delivery.Validators
{
    public class UserValidator : BaseValidator<UserModel, User>
    { 
        public UserValidator(IUserService userService) : base(userService) 
        {
            RuleFor(x => x.Username)
                   .NotEmpty().WithMessage("Enter username")
                   .MaximumLength(CustomMaxLength).WithMessage($"Username must not exceed {CustomMaxLength} characters");

            RuleFor(x => x.Password)
                   .NotEmpty().WithMessage("Enter password")
                   .MaximumLength(MaxLength).WithMessage($"Password must not exceed {MaxLength} characters")
                   .Matches(RegExpForPassword).WithMessage("Password must contain at least 1 numeric and 1 uppercase character");

            RuleFor(x => x.PasswordConfirm)
                   .Equal(x => x.Password).WithMessage("Passwords don't match");

            RuleFor(x => x.Email)
                   .NotEmpty().WithMessage("Enter email")
                   .EmailAddress().WithMessage("Not valid email adress")
                   .MaximumLength(MaxLength).WithMessage($"Email must not exceed {MaxLength} characters");

            RuleFor(x => x.Role)
                   .IsInEnum().WithMessage("Entered user role doesn't exist");
        }
    }
}