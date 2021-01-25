using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using Delivery.Utils.Extensions;
using Delivery.Utils.Enum;

namespace Delivery.DAL.Repositories
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public DriverRepository(DeliveryContextFactory context) : base(context) { }

        public IEnumerable<Driver> GetAllValidDrivers()
        {
            return _contextFactory.GetContext().Drivers
                   .Where(driver => driver.Status.HasValue)
                   .ToList();
        }

        public Driver FindByUserId(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Drivers.FirstOrDefault(driver => driver.UserId == id);
            }
        }

        public async Task<Driver> FindByUserIdAsync(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Drivers.FirstOrDefaultAsync(driver => driver.UserId == id);
            }
        }

        public void Create(string firstName, string lastName, int? userId)
        {
            Create(new Driver
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = userId
            });
        }

        public async Task CreateAsync(string firstName, string lastName, int? userId)
        {
            await CreateAsync(new Driver
            {
                FirstName = firstName,
                LastName = lastName,
                UserId = userId
            });
        }

        public void DeleteByUserId(int id)
        {
            var driver = FindByUserId(id);
            Delete(driver.Id);
        }

        public async Task DeleteByUserIdAsync(int id)
        {
            var driver = await FindByUserIdAsync(id);
            await DeleteAsync(driver.Id);
        }

        public async Task UpdateAsync(int id, Driver driver)
        {
            using (var context = _contextFactory.GetContext())
            {
                var oldDriver = await GetAsync(id);
                context.Entry(oldDriver).State = EntityState.Detached;

                driver.Id = id;
                driver.Status = oldDriver.Status;
                driver.TripsTotal = oldDriver.TripsTotal;
                driver.UserId = oldDriver.UserId;

                await UpdateAsync(driver);
            }
        }

        public IEnumerable<MemberDriver> GetTop5()
        {
            return _contextFactory.GetContext().Drivers.FromSql("exec [GetTop5]")
            .Select(t => new MemberDriver
            {
                FirstName = t.FirstName,
                LastName = t.LastName,
                Address = t.Address,
                Birthdate = t.Birthdate.Value,
                CellPhone = t.CellPhone,
                TripsTotal = t.TripsTotal
            });

        }

        public IEnumerable<Driver> Sort(IEnumerable<Driver> drivers, string paramName, bool isAsc)
        {
            Func<Driver, string> predicate;
            switch (paramName)
            {
                case "Name":
                    predicate = driver => driver.FirstName;
                    break;
                case "LastName":
                    predicate = driver => driver.LastName;
                    break;
                case "Status":
                default:
                    predicate = driver => ((int)driver.Status).ToString();
                    break;
            }
            return isAsc ? drivers.OrderBy(predicate) : drivers.OrderByDescending(predicate);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync(string query, DriverFilterByEnum? filterField, DriverSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Drivers.Where(driver => driver.Status.HasValue);

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
