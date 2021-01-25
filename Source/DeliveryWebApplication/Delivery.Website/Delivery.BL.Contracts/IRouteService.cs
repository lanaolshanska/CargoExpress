using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.BL.Contracts
{
    public interface IRouteService : IBaseService<Route>
    {
        int GetRouteByWarehousesId(int origWarehouseId, int destWarehouseId);
        Task<int> GetRouteByWarehousesIdAsync(int origWarehouseId, int destWarehouseId);
        Task<IEnumerable<Route>> GetAllAsync(string query, RouteFilterByEnum? filterField, RouteSortByEnum? sortBy, int? take, int? skip);
    }
}