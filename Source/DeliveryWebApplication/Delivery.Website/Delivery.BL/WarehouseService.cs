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
    public class WarehouseService : BaseService<Warehouse>, IWarehouseService
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;

        public WarehouseService(IWarehouseRepository warehouseRepository, IMapper mapper) : base(warehouseRepository)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }

        public IEnumerable<Warehouse> GetStates()
        {
            return _warehouseRepository.GetStates();
        }

        public IEnumerable<Warehouse> GetCities(int stateId)
        {
            return _warehouseRepository.GetCities(stateId);
        }

        public IEnumerable<Warehouse> FilterBy(string parameter)
        {
            return _warehouseRepository.FilterBy(parameter);
        }

        public IEnumerable<Warehouse> Sort(IEnumerable<Warehouse> warehouses, string paramName, bool isAsc)
        {
            return _warehouseRepository.Sort(warehouses, paramName, isAsc);
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync(string query, WarehouseFields? filterField, WarehouseSortByEnum? sortBy, int? take, int? skip)
        {
            return await _warehouseRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }

        public async Task<Warehouse> UpdateAsync(int id, UpdateWarehouseModel item)
        {
            if (await _warehouseRepository.IsCityUniqueAsync(id, item.City))
            {
                var warehouse = _mapper.Map<WarehouseModel, Warehouse>(item);
                warehouse.Id = id;
                await _warehouseRepository.UpdateAsync(warehouse);

                return warehouse;
            }
            else
            {
                throw new System.Exception("Warehouse with this city name already exists");
            }
        }

        public async Task<int> CreateAsync(AddWarehouseModel item)
        {
            if (await _warehouseRepository.IsCityUniqueAsync(item.City))
            {
                var warehouse = _mapper.Map<WarehouseModel, Warehouse>(item);
                await _warehouseRepository.CreateAsync(warehouse);
                return warehouse.Id;
            }
            else
            {
                throw new System.Exception("Warehouse with this city name already exists");
            }
        }

        public async Task<IDictionary<int, string>> GetFieldAsync(WarehouseFields field)
        {
            return await _warehouseRepository.GetFieldAsync(field);
        }
    }
}