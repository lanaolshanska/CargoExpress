using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class UpdateCargoValidator : BaseValidator<UpdateCargoModel, Cargo>
    {
        public UpdateCargoValidator(ICargoService cargoService, IContactService contactService, IWarehouseService warehouseService) : base(cargoService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(cargo => $"Cargo with id '{cargo.Id}' doesn't exist");

            RuleFor(x => x)
                .SetValidator(new CargoValidator(cargoService, contactService, warehouseService));
        }
    }
}