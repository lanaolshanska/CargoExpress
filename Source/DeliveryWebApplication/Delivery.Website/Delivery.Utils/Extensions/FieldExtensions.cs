using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Delivery.Utils.Extensions
{
    public static class FieldExtensions
    {
        public static async Task<IDictionary<int, string>> GetFieldAsync(this IQueryable<Warehouse> queryable, WarehouseFields? fieldName)
        {
            switch (fieldName)
            {
                case WarehouseFields.City:
                    return await queryable.GroupBy(t => t.City)
                                    .Select(t => t.FirstOrDefault())
                                    .ToDictionaryAsync(t => t.Id, t => t.City);

                case WarehouseFields.State:
                default:
                    return await queryable.GroupBy(t => t.State)
                                    .Select(t => t.FirstOrDefault())
                                    .ToDictionaryAsync(t => t.Id, t => t.State);
            }
        }
    }
}