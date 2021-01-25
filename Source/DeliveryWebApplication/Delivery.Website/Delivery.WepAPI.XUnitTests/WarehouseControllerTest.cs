using Delivery.DAL;
using Delivery.DAL.Contracts;
using Delivery.DAL.Repositories;
using Delivery.Models;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Delivery.WepAPI.XUnitTests
{
    public class WarehouseServiceTest
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly Mock<DeliveryAPIContext> _apiContext;
        private readonly Mock<DbSet<Warehouse>> _warehouseDbSet;

        private IQueryable<Warehouse> WarehouseTestData = new List<Warehouse> {
            new Warehouse { City = "A", Id = 1, State = "Alabama" },
            new Warehouse { City = "B", Id = 2, State = "Alabama" },
            new Warehouse { City = "C", Id = 3, State = "Alaska" }
        }.AsQueryable(); 
 
        public WarehouseServiceTest()
        {
            _apiContext = new Mock<DeliveryAPIContext>();
            _warehouseDbSet = WarehouseTestData.BuildMockDbSet();

            _apiContext.Setup(context => context.Set<Warehouse>()).Returns(_warehouseDbSet.Object);

            _warehouseRepository = new WarehouseRepository(_apiContext.Object);
        }

        [Fact]
        public void GetStatesTest()
        {
            IEnumerable<Warehouse> result = _warehouseRepository.GetStatesAsync().ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, warehouse => warehouse.State.Equals("Alabama"));
            Assert.Contains(result, warehouse => warehouse.State.Equals("Alaska"));
        }
        
        [Fact]
        public void GetCitiesTest()
        {
            IEnumerable<Warehouse> result = _warehouseRepository.GetCitiesAsync(1).ToList();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, warehouse => warehouse.City.Equals("A"));
            Assert.Contains(result, warehouse => warehouse.City.Equals("B"));
        }
    }
}