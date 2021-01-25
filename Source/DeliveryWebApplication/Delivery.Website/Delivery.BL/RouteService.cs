using System.Collections.Generic;
using System.Threading.Tasks;
using Delivery.BL.Contracts;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;

namespace Delivery.BL
{
    public class RouteService : BaseService<Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;

        public RouteService(IRouteRepository routeRepository) : base(routeRepository)
        {
            _routeRepository = routeRepository;
        }

        public int GetRouteByWarehousesId(int origWarehouseId, int destWarehouseId)
        {
            return _routeRepository.GetRouteByWarehousesId(origWarehouseId, destWarehouseId);
        }

        public async Task<int> GetRouteByWarehousesIdAsync(int origWarehouseId, int destWarehouseId)
        {
            return await _routeRepository.GetRouteByWarehousesIdAsync(origWarehouseId, destWarehouseId);
        }

        public async Task<IEnumerable<Route>> GetAllAsync(string query, RouteFilterByEnum? filterField, RouteSortByEnum? sortBy, int? take, int? skip)
        {
            return await _routeRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }
    }
}