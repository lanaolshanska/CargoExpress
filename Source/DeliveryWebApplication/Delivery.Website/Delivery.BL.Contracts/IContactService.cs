using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.BL.Contracts
{
    public interface IContactService : IBaseService<Contact>
    {
        Contact FindContactByUserId(int id);
        Task<Contact> FindContactByUserIdAsync(int id);
        int CreateContact(Contact contact);
        Task<int> CreateAsync(AddContactModel contact);
        Task<Contact> UpdateAsync(int id, UpdateContactModel item);
        IEnumerable<Contact> Sort(IEnumerable<Contact> contacts, string paramName, bool isAsc);
        Task<IEnumerable<Contact>> GetAllAsync(string query, ContactFilterByEnum? filterField, ContactSortByEnum? sortBy, int? take, int? skip);
    }
}