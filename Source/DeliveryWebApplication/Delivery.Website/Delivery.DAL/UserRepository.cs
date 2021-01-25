using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;
using Delivery.Utils.Extensions;

namespace Delivery.DAL.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DeliveryContextFactory context) : base(context) { }

        public override IEnumerable<User> GetAll()
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Users.OrderBy(user => user.Id).ToList();
            }
        }

        public bool IsEmailExist(string email)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Users.Where(user => user.Email.Equals(email))
                         .Select(user => user)
                         .FirstOrDefault() != null;
            }
        }

        public async Task<bool> IsEmailUniqueAsync(string email)
        {
            using (var context = _contextFactory.GetContext())
            {
                return !await context.Users.AnyAsync(user => user.Email.Equals(email));
            }
        }

        public async Task<bool> IsEmailUniqueAsync(int id, string email)
        {
            using (var context = _contextFactory.GetContext())
            {
                var user = await context.Users.FirstOrDefaultAsync(t => t.Email.Equals(email));
                if (user != null)
                {
                    context.Entry(user).State = EntityState.Detached;
                    return user.Id == id;
                }
                else
                {
                    return true;
                }
            }
        }

        public User FindUserByEmailAndPassword(string email, string password)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Users.FirstOrDefault(user => user.Email.Equals(email)
                                        && user.Password.Equals(password));
            }
        }

        public async Task<User> FindUserByEmailAndPasswordAsync(string email, string password)
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Users.FirstOrDefaultAsync(user => user.Email.Equals(email)
                                        && user.Password.Equals(password));
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync(string query, UserFilterByEnum? filterField, UserSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Users.AsQueryable();

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