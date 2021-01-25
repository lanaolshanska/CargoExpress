using Delivery.BL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.BL
{
    public interface IUserService : IBaseService<User>
    {
        int Create(string userName, string password, string email, Role role);
        Task <int> CreateAsync(string userName, string password, string email, Role role);
        bool IsEmailExist(string email);
        User FindUserByEmailAndPassword(string email, string password);
        Task<User> FindUserByEmailAndPasswordAsync(string email, string password);
        Task<int> CreateAsync(AddUserModel item);
        Task<User> UpdateAsync(int id, UpdateUserModel item);
        Task<IEnumerable<User>> GetAllAsync(string query, UserFilterByEnum? filterField, UserSortByEnum? sortBy, int? take, int? skip);
    }
}