using Delivery.BL.Contracts;
using Delivery.Models;
using FluentValidation;
using System;
using System.Threading.Tasks;

namespace Delivery.Validators
{
    public class WarehouseValidator : BaseValidator<WarehouseModel, Warehouse>
    {
        public WarehouseValidator(IWarehouseService warehouseService) : base(warehouseService)
        {
            RuleFor(x => x.State)
                   .NotEmpty().WithMessage("Enter name of state")
                   .MaximumLength(MaxLength).WithMessage($"State must not exceed {MaxLength} characters")
                   .Matches(RegExpForChars).WithMessage("State must contain only letters");

            RuleFor(x => x.City)
                   .NotEmpty().WithMessage("Enter name of city")
                   .MaximumLength(MaxLength).WithMessage($"City must not exceed {MaxLength} characters")
                   .Matches(RegExpForChars).WithMessage("City must contain only letters");

            RuleFor(x => x.Phone)
                   .Matches(RegExpForDigits).WithMessage("Phone must contain only digits")
                   .MaximumLength(MaxLength).WithMessage($"Phone must not exceed {MaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Phone));

            RuleFor(x => x.Postcode)
                   .Matches(RegExpForDigits).WithMessage("Postcode must contain only digits")
                   .MaximumLength(MaxLength).WithMessage($"Postcode must not exceed {MaxLength} characters")
                   .Unless(x => string.IsNullOrEmpty(x.Phone));
        }
    }
}