using AutoMapper;
using Delivery.BL.Contracts;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.BL
{
    public class CargoService : BaseService<Cargo>, ICargoService
    {
        private readonly ICargoRepository _cargoRepository;
        private readonly IContactService _contactService;
        private readonly IRouteService _routeService;
        private readonly IMapper _mapper;

        public CargoService(
            ICargoRepository cargoRepository,
            IContactService contactService,
            IRouteService routeService,
            IMapper mapper)
            : base(cargoRepository)
        {
            _cargoRepository = cargoRepository;
            _contactService = contactService;
            _routeService = routeService;
            _mapper = mapper;
        }

        new public int Create(Cargo cargo)
        {
            base.Create(cargo);
            return cargo.Id;
        }

        public IEnumerable<Cargo> FilterByUser(int id)
        {
            return _cargoRepository.FilterByUser(id);
        }

        public IEnumerable<Cargo> FilterByDriver(int id)
        {
            return _cargoRepository.FilterByDriver(id);
        }

        public IEnumerable<Cargo> FilterByStatus(CargoStatus status)
        {
            return _cargoRepository.FilterByStatus(status);
        }

        public IQueryable<Cargo> FilterAsync(int driverId, CargoStatus status)
        {
            return _cargoRepository.FilterAsync(driverId, status);
        }

        public IEnumerable<Cargo> Sort(IEnumerable<Cargo> cargos, string paramName, bool isAsc)
        {
            return _cargoRepository.Sort(cargos, paramName, isAsc);
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync(string query, CargoFilterByEnum? filterField, CargoSortByEnum? sortBy, int? take, int? skip)
        {
            return await _cargoRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }

        public async Task<Cargo> UpdateAsync(int id, UpdateCargoModel item)
        {
            var cargo = _mapper.Map<UpdateCargoModel, Cargo>(item);
            cargo.RouteId = await _routeService.GetRouteByWarehousesIdAsync(item.OriginWarehouseId, item.DestinationWarehouseId);
            cargo.Status = CargoStatus.New;
            cargo.Id = id;

            await _cargoRepository.UpdateAsync(cargo);
            return cargo;
        }

        public async Task<int> CreateOrderAsync(AddCargoModel item)
        {
            var cargo = _mapper.Map<CargoModel, Cargo>(item);
            cargo.RouteId = await _routeService.GetRouteByWarehousesIdAsync(item.OriginWarehouseId, item.DestinationWarehouseId);
            cargo.Status = CargoStatus.New;

            await _cargoRepository.CreateAsync(cargo);
            return cargo.Id;
        }
    }
}