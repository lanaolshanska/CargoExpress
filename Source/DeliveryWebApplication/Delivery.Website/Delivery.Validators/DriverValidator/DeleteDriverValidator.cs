using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class DeleteDriverValidator : BaseValidator<DeleteDriverModel, Driver>
    {
        public DeleteDriverValidator(IDriverService driverService) : base(driverService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(model => $"Driver with id '{model.Id}' doesn't exist");
        }
    }
}
