using Delivery.Models;
using Delivery.Utils.Enum;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Delivery.Utils.Extensions
{
    public static class FilterExtensions
    {
        public static IQueryable<Warehouse> WithFilter(this IQueryable<Warehouse> queryable, WarehouseFields? filterField, string filterParameter)
        {
            Expression<Func<Warehouse, bool>> getKeySelector(WarehouseFields? column, string filterString)
            {
                switch (column)
                {
                    case WarehouseFields.City:
                        return x => x.City.Equals(filterString);
                    case WarehouseFields.State:
                        return x => x.State.Equals(filterString);
                    default:
                        return x => x.State.Equals(filterString) || x.City.Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }

        public static IQueryable<Driver> WithFilter(this IQueryable<Driver> queryable, DriverFilterByEnum? filterField, string filterParameter)
        {
            Expression<Func<Driver, bool>> getKeySelector(DriverFilterByEnum? column, string filterString)
            {
                switch (column)
                {
                    case DriverFilterByEnum.StartedDrivingYear:
                        return x => x.StartedDrivingYear.ToString().Equals(filterString);

                    case DriverFilterByEnum.TripsTotal:
                        return x => x.TripsTotal.ToString().Equals(filterString);

                    case DriverFilterByEnum.Status:
                    default:
                        return x => x.Status.ToString().Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }

        public static IQueryable<User> WithFilter(this IQueryable<User> queryable, UserFilterByEnum? filterField, string filterParameter)
        {
            Expression<Func<User, bool>> getKeySelector(UserFilterByEnum? column, string filterString)
            {
                switch (column)
                {
                    case UserFilterByEnum.Username:
                        return x => x.Username.Equals(filterString);

                    case UserFilterByEnum.Role:
                    default:
                        return x => x.Role.ToString().Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }

        public static IQueryable<Contact> WithFilter(this IQueryable<Contact> queryable, ContactFilterByEnum? filterField, string filterParameter)
        {
            Expression<Func<Contact, bool>> getKeySelector(ContactFilterByEnum? column, string filterString)
            {
                switch (column)
                {
                    case ContactFilterByEnum.FirstName:
                        return x => x.FirstName.Equals(filterString);

                    case ContactFilterByEnum.LastName:
                    default:
                        return x => x.LastName.ToString().Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }

        public static IQueryable<Route> WithFilter(this IQueryable<Route> queryable, RouteFilterByEnum? filterField, string filterParameter)
        {
            Expression<Func<Route, bool>> getKeySelector(RouteFilterByEnum? column, string filterString)
            {
                switch (column)
                {
                    case RouteFilterByEnum.Distance:
                    default:
                        return x => x.Distance.ToString().Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }

        public static IQueryable<Cargo> WithFilter(this IQueryable<Cargo> queryable, CargoFilterByEnum? filterField, string filterParameter)
        {
            Expression<Func<Cargo, bool>> getKeySelector(CargoFilterByEnum? column, string filterString)
            {
                switch (column)
                {
                    case CargoFilterByEnum.Weight:
                        return x => x.Weight.ToString().Equals(filterString);

                    case CargoFilterByEnum.Volume:
                        return x => x.Volume.ToString().Equals(filterString);

                    case CargoFilterByEnum.UserId:
                        return x => x.UserId.ToString().Equals(filterString);

                    case CargoFilterByEnum.DriverId:
                        return x => x.DriverId.ToString().Equals(filterString);

                    default:
                        return x => x.Status.ToString().Equals(filterString);
                }
            }

            return queryable.Where(getKeySelector(filterField, filterParameter));
        }
    }
}