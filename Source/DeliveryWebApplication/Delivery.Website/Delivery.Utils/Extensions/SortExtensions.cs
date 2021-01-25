using Delivery.Models;
using Delivery.Utils.Enum;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace Delivery.Utils.Extensions
{
    public static class SortExtensions
    {
        public static IQueryable<Warehouse> WithSort(this IQueryable<Warehouse> queryable, WarehouseSortByEnum sort)
        {
            Expression<Func<Warehouse, object>> getKeySelector(WarehouseSortByEnum column)
            {
                switch (column)
                {
                    case WarehouseSortByEnum.City:
                        return x => x.City;
                    case WarehouseSortByEnum.Id:
                        return x => x.Id;
                    default:
                        return x => x.State;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }

        public static IQueryable<Driver> WithSort(this IQueryable<Driver> queryable, DriverSortByEnum sort)
        {
            Expression<Func<Driver, object>> getKeySelector(DriverSortByEnum column)
            {
                switch (column)
                {
                    case DriverSortByEnum.FirstName:
                        return x => x.FirstName;
                    case DriverSortByEnum.LastName:
                        return x => x.LastName;
                    default:
                        return x => (int)x.Status;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }

        public static IQueryable<User> WithSort(this IQueryable<User> queryable, UserSortByEnum sort)
        {
            Expression<Func<User, object>> getKeySelector(UserSortByEnum column)
            {
                switch (column)
                {
                    case UserSortByEnum.Username:
                        return x => x.Username;
                    case UserSortByEnum.Email:
                        return x => x.Email;
                    default:
                        return x => x.Role;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }

        public static IQueryable<Contact> WithSort(this IQueryable<Contact> queryable, ContactSortByEnum sort)
        {
            Expression<Func<Contact, object>> getKeySelector(ContactSortByEnum column)
            {
                switch (column)
                {
                    case ContactSortByEnum.LastName:
                        return x => x.LastName;
                    case ContactSortByEnum.Email:
                        return x => x.Email;
                    default:
                        return x => x.FirstName;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }

        public static IQueryable<Route> WithSort(this IQueryable<Route> queryable, RouteSortByEnum sort)
        {
            Expression<Func<Route, object>> getKeySelector(RouteSortByEnum column)
            {
                switch (column)
                {
                    case RouteSortByEnum.Distance:
                        return x => x.Distance;
                    default:
                        return x => x.Id;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }

        public static IQueryable<Cargo> WithSort(this IQueryable<Cargo> queryable, CargoSortByEnum sort)
        {
            Expression<Func<Cargo, object>> getKeySelector(CargoSortByEnum column)
            {
                switch (column)
                {
                    case CargoSortByEnum.Weight:
                        return x => x.Weight;

                    case CargoSortByEnum.Volume:
                        return x => x.Volume;

                    default:
                        return x => (int)x.Status;
                }
            }

            return queryable.OrderBy(getKeySelector(sort));
        }
    }
}