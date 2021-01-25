using Delivery.Models;
using System.Linq;

namespace Delivery.Utils.Extensions
{
    public static class SearchExtensions
    {
        public static IQueryable<Warehouse> Search(this IQueryable<Warehouse> queryable, string query)
        {
            return queryable.Where(item => item.City.Contains(query) ||
                                           item.State.Contains(query) ||
                                           item.Phone.Contains(query) ||
                                           item.Postcode.Contains(query));
        }

        public static IQueryable<Driver> Search(this IQueryable<Driver> queryable, string query)
        {
            return queryable.Where(item => item.FirstName.Contains(query) ||
                                           item.LastName.Contains(query) ||
                                           item.Address.Contains(query) ||
                                           item.CellPhone.Contains(query) ||
                                           item.StartedDrivingYear.ToString().Contains(query) ||
                                           item.TripsTotal.ToString().Contains(query));
        }

        public static IQueryable<User> Search(this IQueryable<User> queryable, string query)
        {
            return queryable.Where(item => item.Username.Contains(query) ||
                                           item.Email.Contains(query) ||
                                           item.Role.ToString().Contains(query));
        }

        public static IQueryable<Contact> Search(this IQueryable<Contact> queryable, string query)
        {
            return queryable.Where(item => item.FirstName.Contains(query) ||
                                           item.LastName.Contains(query) ||
                                           item.CellPhone.Contains(query) ||
                                           item.Address.Contains(query) ||
                                           item.Email.Contains(query));
        }

        public static IQueryable<Route> Search(this IQueryable<Route> queryable, string query)
        {
            return queryable.Where(item => item.Distance.ToString().Contains(query));
        }

        public static IQueryable<Cargo> Search(this IQueryable<Cargo> queryable, string query)
        {
            return queryable.Where(item => item.Weight.ToString().Contains(query) ||
                                           item.Volume.ToString().Contains(query));
        }
    }
}