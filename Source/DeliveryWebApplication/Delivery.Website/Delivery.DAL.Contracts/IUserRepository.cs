using Delivery.DAL.Interfaces;
using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.DAL.Contracts
{
    public interface IUserRepository : IBaseRepository<User>
    {
        bool IsEmailExist(string email);
        Task<bool> IsEmailUniqueAsync(string email);
        Task<bool> IsEmailUniqueAsync(int id, string email);
        User FindUserByEmailAndPassword(string email, string password);
        Task<User> FindUserByEmailAndPasswordAsync(string email, string password);
        Task<IEnumerable<User>> GetAllAsync(string query, UserFilterByEnum? filterField, UserSortByEnum? sortBy, int? take, int? skip);
    }
}