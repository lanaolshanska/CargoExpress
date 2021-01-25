using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.BL.Contracts
{
    public interface IDriverService : IBaseService<Driver>
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
        Task<int> CreateAsync(AddDriverModel item);
        Task<Driver> UpdateAsync(int id, UpdateDriverModel item);
        Task<IEnumerable<Driver>> GetAllAsync(string query, DriverFilterByEnum? filterField, DriverSortByEnum? sortBy, int? take, int? skip);
    }
}