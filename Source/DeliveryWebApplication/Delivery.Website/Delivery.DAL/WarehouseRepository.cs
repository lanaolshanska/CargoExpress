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
    public class WarehouseRepository : BaseRepository<Warehouse>, IWarehouseRepository
    {
        public WarehouseRepository(DeliveryContextFactory context) : base(context) { }

        public IEnumerable<Warehouse> GetCities(int stateId)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Warehouses.Where(warehouses => warehouses.State == context.Warehouses.FirstOrDefault(warehouse => warehouse.Id == stateId).State).ToList();
            }
        }

        public IEnumerable<Warehouse> GetStates()
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Warehouses.GroupBy(warehouse => warehouse.State)
                         .Select(warehouse => warehouse.FirstOrDefault()).ToList();
            }
        }

        public IEnumerable<Warehouse> FilterBy(string parameter)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Warehouses.Where(warehouse => warehouse.State.Equals(parameter))
                         .Select(warehouse => warehouse).ToList();
            }
        }

        public IEnumerable<Warehouse> Sort(IEnumerable<Warehouse> warehouses, string paramName, bool isAsc)
        {
            Func<Warehouse, string> predicate;
            switch (paramName)
            {
                case "City":
                    predicate = warehouse => warehouse.City;
                    break;
                case "State":
                default:
                    predicate = warehouse => warehouse.State;
                    break;
            }
            return isAsc ? warehouses.OrderBy(predicate).ToList() : warehouses.OrderByDescending(predicate).ToList();
        }

        public async Task<bool> IsCityUniqueAsync(string state)
        {
            using (var context = _contextFactory.GetContext())
            {
                return !await context.Warehouses.AnyAsync(t => t.City.Equals(state));
            }
        }

        public async Task<bool> IsCityUniqueAsync(int id, string city)
        {
            using (var context = _contextFactory.GetContext())
            {
                var warehouse = await context.Warehouses.FirstOrDefaultAsync(t => t.City.Equals(city));
                if (warehouse != null)
                {
                    context.Entry(warehouse).State = EntityState.Detached;
                    return warehouse.Id == id;
                }
                else
                {
                    return true;
                }
            }
        }

        public async Task<IEnumerable<Warehouse>> GetAllAsync(string query, WarehouseFields? filterField, WarehouseSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Warehouses.Where(t => t.State != null);

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

        public async Task<IDictionary<int, string>> GetFieldAsync(WarehouseFields field)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Warehouses.Where(t => t.State != null);
                return await result.GetFieldAsync(field);
            }
        }
    }
}