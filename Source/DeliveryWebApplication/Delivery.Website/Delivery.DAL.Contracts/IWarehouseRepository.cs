using Delivery.DAL.Interfaces;
using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.DAL.Contracts
{
    public interface IWarehouseRepository : IBaseRepository<Warehouse>
    {
        IEnumerable<Warehouse> GetStates();
        IEnumerable<Warehouse> GetCities(int stateId);
        IEnumerable<Warehouse> FilterBy(string parameter);
        IEnumerable<Warehouse> Sort(IEnumerable<Warehouse> warehouses, string paramName, bool isAsc);
        Task<bool> IsCityUniqueAsync(string city);
        Task<bool> IsCityUniqueAsync(int id, string city);
        Task<IEnumerable<Warehouse>> GetAllAsync(string query, WarehouseFields? filterField, WarehouseSortByEnum? sortBy, int? take, int? skip);
        Task<IDictionary<int, string>> GetFieldAsync(WarehouseFields field);
    }
}