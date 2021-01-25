using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;
using Delivery.Utils.Extensions;

namespace Delivery.DAL.Repositories
{
    public class CargoRepository : BaseRepository<Cargo>, ICargoRepository
    {
        public CargoRepository(DeliveryContextFactory context) : base(context) { }

        public override IEnumerable<Cargo> GetAll()
        {
            return _contextFactory.GetContext().Cargos
                .OrderBy(cargo => cargo.Status)
                .Include(t => t.Recipient)
                .Include(t => t.Sender)
                .Include(t => t.Driver)
                .Include(t => t.Route)
                .ToList();
        }

        public override Cargo Get(int id)
        {
            return _contextFactory.GetContext().Cargos
                .Include(t => t.Recipient)
                .Include(t => t.Sender)
                .Include(t => t.Driver)
                .Include(t => t.Route)
                .FirstOrDefault(t => t.Id == id);
        }

        new public int Create(Cargo cargo)
        {
            base.Create(cargo);
            return cargo.Id;
        }

        public IEnumerable<Cargo> FilterByStatus(CargoStatus status)
        {
            return _contextFactory.GetContext().Cargos.Where(cargo => cargo.Status == status);
        }

        public IEnumerable<Cargo> FilterByUser(int id)
        {
            return _contextFactory.GetContext().Cargos.Where(cargo => cargo.UserId == id);
        }

        public IEnumerable<Cargo> FilterByDriver(int id)
        {
            return _contextFactory.GetContext().Cargos.Where(cargo => cargo.DriverId == id);
        }

        public IQueryable<Cargo> FilterAsync(int driverId, CargoStatus status)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Cargos.Where(cargo => cargo.DriverId == driverId && cargo.Status == status);
            }
        }

        public IEnumerable<Cargo> Sort(IEnumerable<Cargo> cargos, string paramName, bool isAsc)
        {
            Func<Cargo, string> predicate;
            switch (paramName)
            {
                case "Status":
                default:
                    predicate = cargo => ((int)cargo.Status).ToString();
                    break;
            }
            return isAsc ? cargos.OrderBy(predicate) : cargos.OrderByDescending(predicate);
        }

        public async Task<IEnumerable<Cargo>> GetAllAsync(string query, CargoFilterByEnum? filterField, CargoSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Cargos.AsQueryable();

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