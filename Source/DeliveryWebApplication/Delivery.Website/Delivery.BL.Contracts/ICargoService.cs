using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.BL.Contracts
{
    public interface ICargoService : IBaseService<Cargo>
    {
        IEnumerable<Cargo> FilterByUser(int id);
        IEnumerable<Cargo> FilterByDriver(int id);
        IEnumerable<Cargo> FilterByStatus(CargoStatus status);
        IQueryable<Cargo> FilterAsync(int driverId, CargoStatus status);
        IEnumerable<Cargo> Sort(IEnumerable<Cargo> cargos, string paramName, bool isAsc);
        Task<int> CreateOrderAsync(AddCargoModel item);
        Task<Cargo> UpdateAsync(int id, UpdateCargoModel item);
        Task<IEnumerable<Cargo>> GetAllAsync(string query, CargoFilterByEnum? filterField, CargoSortByEnum? sortBy, int? take, int? skip);
    }
}