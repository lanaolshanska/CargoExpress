using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class DeleteCargoValidator : BaseValidator<DeleteCargoModel, Cargo>
    {
        public DeleteCargoValidator(ICargoService cargoService) : base(cargoService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(cargo => $"Cargo with id '{cargo.Id}' doesn't exist");
        }
    }
}
