using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;
using Delivery.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DAL.Repositories
{
    public class RouteRepository : BaseRepository<Route>, IRouteRepository
    {
        public RouteRepository(DeliveryContextFactory context) : base(context) { }

        public int GetRouteByWarehousesId(int origWarehouseId, int destWarehouseId)
        {
            using (var context = _contextFactory.GetContext())
            {
                var route = context.Routes.FirstOrDefault(r => r.OriginWarehouseId == origWarehouseId
                                                && r.DestinationWarehouseId == destWarehouseId);
                if (route != null)
                {
                    return route.Id;
                }
                return default(int);
            }
        }

        public async Task<int> GetRouteByWarehousesIdAsync(int origWarehouseId, int destWarehouseId)
        {
            using (var context = _contextFactory.GetContext())
            {
                var route = await context.Routes.FirstOrDefaultAsync(r => r.OriginWarehouseId == origWarehouseId
                                                && r.DestinationWarehouseId == destWarehouseId);

                return route != null ? route.Id : default(int);
            }
        }

        public async Task<IEnumerable<Route>> GetAllAsync(string query, RouteFilterByEnum? filterField, RouteSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Routes.AsQueryable();

                if (!String.IsNullOrEmpty(query))
                {
                    result = filterField.HasValue
                        ? result.WithFilter(filterField, query)
                        : result.Search(query);
                }

                if (sortBy.HasValue)
                    result = result.WithSort(sortBy.Value);

                if (skip.HasValue)
                    result = result.Skip(skip.Value);

                if (take.HasValue)
                    result = result.Take(take.Value);

                return await result.ToListAsync();
            }
        }
    }
}