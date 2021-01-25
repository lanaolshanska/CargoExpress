using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class UpdateDriverValidator : BaseValidator<UpdateDriverModel, Driver>
    {
        public UpdateDriverValidator(IDriverService driverService) : base(driverService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(model => $"Driver with id '{model.Id}' doesn't exist");

            RuleFor(x => x)
                .SetValidator(new DriverValidator(driverService));
        }
    }
}