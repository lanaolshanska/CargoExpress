using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;

namespace Delivery.Validators
{
    public class UpdateWarehouseValidator : BaseValidator<UpdateWarehouseModel, Warehouse>
    {
        public UpdateWarehouseValidator(IWarehouseService warehouseService) : base(warehouseService)
        {
            RuleFor(x => x.Id)
                .MustAsync(IsExistAsync).WithMessage(warehouse => $"Warehouse with id '{warehouse.Id}' doesn't exist");

            RuleFor(x => x)
                .SetValidator(new WarehouseValidator(warehouseService));
        }
    }
}