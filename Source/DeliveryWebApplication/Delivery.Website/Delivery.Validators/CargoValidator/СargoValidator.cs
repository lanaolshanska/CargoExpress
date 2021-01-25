using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using FluentValidation;
using System.Threading;
using System.Threading.Tasks;

namespace Delivery.Validators
{
    public class CargoValidator : BaseValidator<CargoModel, Cargo>
    {
        private readonly IContactService _contactService;
        private readonly IWarehouseService _warehouseService;

        public CargoValidator(ICargoService cargoService, IContactService contactService, IWarehouseService warehouseService) : base(cargoService)
        {
            _contactService = contactService;
            _warehouseService = warehouseService;

            RuleFor(x => x.Weight)
                    .NotNull().WithMessage("Enter cargo weight")
                    .GreaterThan(Zero).WithMessage($"Cargo weigt must be greater than {Zero}");

            RuleFor(x => x.Volume)
                    .NotNull().WithMessage("Enter cargo volume")
                    .GreaterThan(Zero).WithMessage($"Cargo volume must be greater than {Zero}");

            RuleFor(x => x.SenderContactId)
                    .NotNull().WithMessage("Enter sender id")
                    .GreaterThan(Zero).WithMessage($"Sender id must be greater than {Zero}")
                    .MustAsync(IsContactExistAsync).WithMessage(model => $"Sender with id '{model.SenderContactId}' doesn't exist");

            RuleFor(x => x.RecipientContactId)
                    .NotNull().WithMessage("Enter recipient id")
                    .GreaterThan(Zero).WithMessage($"Recipient id must be greater than {Zero}")
                    .MustAsync(IsContactExistAsync).WithMessage(model => $"Recipient with id '{model.RecipientContactId}' doesn't exist");

            RuleFor(x => x.OriginWarehouseId)
                    .NotNull().WithMessage("Enter origin warehouse id")
                    .GreaterThan(Zero).WithMessage($"Warehouse id must be greater than {Zero}")
                    .MustAsync(IsWarehouseExistAsync).WithMessage(model => $"Warehouse with id '{model.OriginWarehouseId}' doesn't exist");

            RuleFor(x => x.DestinationWarehouseId)
                    .NotNull().WithMessage("Enter destination warehouse id")
                    .GreaterThan(Zero).WithMessage($"Warehouse id must be greater than {Zero}")
                    .MustAsync(IsWarehouseExistAsync).WithMessage(model => $"Warehouse with id '{model.DestinationWarehouseId}' doesn't exist");
        }

        private async Task<bool> IsContactExistAsync(int id, CancellationToken token)
        {
            return await _contactService.GetByIdAsync(id) != null;
        }

        private async Task<bool> IsWarehouseExistAsync(int id, CancellationToken token)
        {
            return await _warehouseService.GetByIdAsync(id) != null;
        }
    }
}