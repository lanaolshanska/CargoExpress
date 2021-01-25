using Delivery.DAL.Interfaces;
using Delivery.Models;
using Delivery.Utils.Enum;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Delivery.DAL.Contracts
{
    public interface IContactRepository : IBaseRepository<Contact>
    {
        Contact FindContactByUserId(int id);
        Task<Contact> FindContactByUserIdAsync(int id);
        int CreateContact(Contact contact);
        Task<int> CreateContactAsync(Contact contact);
        IEnumerable<Contact> Sort(IEnumerable<Contact> contacts, string paramName, bool isAsc);
        Task<IEnumerable<Contact>> GetAllAsync(string query, ContactFilterByEnum? filterField, ContactSortByEnum? sortBy, int? take, int? skip);
    }
}