using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class DriverValidator : BaseValidator<DriverModel, Driver>
    {
        public DriverValidator(IDriverService driverService) : base(driverService)
        {
            RuleFor(x => x.FirstName)
                    .NotEmpty().WithMessage("Enter first name")
                    .MaximumLength(CustomMaxLength).WithMessage($"First name must not exceed {CustomMaxLength} characters")
                    .Matches(RegExpForChars).WithMessage("First name must contain only letters");

            RuleFor(x => x.LastName)
                   .NotEmpty().WithMessage("Enter last name")
                   .MaximumLength(CustomMaxLength).WithMessage($"Last name must not exceed {CustomMaxLength} characters")
                   .Matches(RegExpForChars).WithMessage("Last name must contain only letters");

            RuleFor(x => x.Birthdate)
                   .Must(IsValidDate).WithMessage("Entered date format is invalid")
                   .Unless(x => string.IsNullOrEmpty(x.Birthdate));

            RuleFor(x => x.CellPhone)
                   .Matches(RegExpForDigits).WithMessage("Phone must contain only digits")
                   .MaximumLength(CustomMaxLength).WithMessage($"Phone must not exceed {CustomMaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.CellPhone));

            RuleFor(x => x.Address)
                   .MaximumLength(MaxLength).WithMessage($"Address must not exceed {MaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Address));

            RuleFor(x => x.StartedDrivingYear)
                   .InclusiveBetween(MinYearRange, MaxYearRange).WithMessage($"Year must be in range between {MinYearRange} and {MaxYearRange}")
                   .Unless(x => !x.StartedDrivingYear.HasValue);

            RuleFor(x => x.HasCriminalRecord)
                   .NotNull().WithMessage("This field must be true or false");
        }
    }
}