using AutoMapper;
using Delivery.BL.Contracts;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delivery.BL
{
    public class DriverService : BaseService<Driver>, IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper) : base(driverRepository)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public void Create(string firstName, string lastName, int? userId)
        {
            _driverRepository.Create(firstName, lastName, userId);
        }

        public async Task CreateAsync(string firstName, string lastName, int? userId)
        {
            await _driverRepository.CreateAsync(firstName, lastName, userId);
        }

        public void DeleteByUserId(int id)
        {
            _driverRepository.DeleteByUserId(id);
        }

        public async Task DeleteByUserIdAsync(int id)
        {
            await _driverRepository.DeleteByUserIdAsync(id);
        }

        public Driver FindByUserId(int id)
        {
            return _driverRepository.FindByUserId(id);
        }

        public async Task<Driver> FindByUserIdAsync(int id)
        {
            return await _driverRepository.FindByUserIdAsync(id);
        }

        public IEnumerable<Driver> GetAllValidDrivers()
        {
            return _driverRepository.GetAllValidDrivers();
        }

        public IEnumerable<MemberDriver> GetTop5()
        {
            return _driverRepository.GetTop5();
        }

        public IEnumerable<Driver> Sort(IEnumerable<Driver> drivers, string paramName, bool isAsc)
        {
            return _driverRepository.Sort(drivers, paramName, isAsc);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync(string query, DriverFilterByEnum? filterField, DriverSortByEnum? sortBy, int? take, int? skip)
        {
            return await _driverRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }

        public async Task<Driver> UpdateAsync(int id, UpdateDriverModel item)
        {
            var driver = _mapper.Map<DriverModel, Driver>(item);
            await _driverRepository.UpdateAsync(id, driver);

            return driver;
        }

        public async Task<int> CreateAsync(AddDriverModel item)
        {
            var driver = _mapper.Map<DriverModel, Driver>(item);
            await _driverRepository.CreateAsync(driver);

            return driver.Id;
        }
    }
}