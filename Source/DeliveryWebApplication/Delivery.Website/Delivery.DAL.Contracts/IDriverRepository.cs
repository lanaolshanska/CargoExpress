using Delivery.DAL.Interfaces;
using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.DAL.Contracts
{
    public interface IDriverRepository : IBaseRepository<Driver>
    {
        void Create(string firstName, string lastName, int? userId);
        Task CreateAsync(string firstName, string lastName, int? userId);
        void DeleteByUserId(int id);
        Task DeleteByUserIdAsync(int id);
        Driver FindByUserId(int id);
        Task<Driver> FindByUserIdAsync(int id);
        IEnumerable<Driver> GetAllValidDrivers();
        IEnumerable<MemberDriver> GetTop5();
        IEnumerable<Driver> Sort(IEnumerable<Driver> drivers, string paramName, bool isAsc);
        Task UpdateAsync(int id, Driver driver);
        Task<IEnumerable<Driver>> GetAllAsync(string query, DriverFilterByEnum? filterField, DriverSortByEnum? sortBy, int? take, int? skip);
    }
}