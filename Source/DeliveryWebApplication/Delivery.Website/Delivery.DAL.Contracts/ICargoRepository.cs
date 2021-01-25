using Delivery.DAL.Interfaces;
using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.DAL.Contracts
{
    public interface ICargoRepository : IBaseRepository<Cargo>
    {
        IEnumerable<Cargo> FilterByStatus(CargoStatus status);
        IEnumerable<Cargo> FilterByUser(int id);
        IEnumerable<Cargo> FilterByDriver(int id);
        IQueryable<Cargo> FilterAsync(int driverId, CargoStatus status);
        IEnumerable<Cargo> Sort(IEnumerable<Cargo> cargos, string paramName, bool isAsc);
        Task<IEnumerable<Cargo>> GetAllAsync(string query, CargoFilterByEnum? filterField, CargoSortByEnum? sortBy, int? take, int? skip);
    }
}