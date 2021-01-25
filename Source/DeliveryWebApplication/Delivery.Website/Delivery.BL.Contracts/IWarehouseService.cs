using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Delivery.BL.Contracts
{
    public interface IWarehouseService : IBaseService<Warehouse>
    {
        IEnumerable<Warehouse> GetStates();
        IEnumerable<Warehouse> GetCities(int stateId);
        IEnumerable<Warehouse> FilterBy(string parameter);
        IEnumerable<Warehouse> Sort(IEnumerable<Warehouse> warehouses, string paramName, bool isAsc);
        Task<int> CreateAsync(AddWarehouseModel item);
        Task<Warehouse> UpdateAsync(int id, UpdateWarehouseModel item);
        Task<IEnumerable<Warehouse>> GetAllAsync(string query, WarehouseFields? filterField, WarehouseSortByEnum? sortBy, int? take, int? skip);
        Task<IDictionary<int, string>> GetFieldAsync(WarehouseFields field);
    }
}