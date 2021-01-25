using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Delivery.BL.Contracts;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Models.DTO;
using Delivery.Utils.Enum;

namespace Delivery.BL
{
    public class ContactService : BaseService<Contact>, IContactService
    {
        private readonly IContactRepository _contactRepository;
        private readonly IMapper _mapper;

        public ContactService(IContactRepository contactRepository, IMapper mapper) : base(contactRepository)
        {
            _contactRepository = contactRepository;
            _mapper = mapper;
        }
        
        public Contact FindContactByUserId(int id)
        {
            return _contactRepository.FindContactByUserId(id);
        }

        public async Task<Contact> FindContactByUserIdAsync(int id)
        {
            return await _contactRepository.FindContactByUserIdAsync(id);
        }

        public int CreateContact(Contact contact)
        {
            return _contactRepository.CreateContact(contact);
        }

        public async Task<int> CreateAsync(AddContactModel item)
        {
            var contact = _mapper.Map<ContactModel, Contact>(item);
            return await _contactRepository.CreateContactAsync(contact);
        }

        public async Task<Contact> UpdateAsync(int id, UpdateContactModel item)
        {
            var contact = _mapper.Map<ContactModel, Contact>(item);
            contact.Id = id;
            await _contactRepository.UpdateAsync(contact);

            return contact;
        }

        public IEnumerable<Contact> Sort(IEnumerable<Contact> contacts, string paramName, bool isAsc)
        {
            return _contactRepository.Sort(contacts, paramName, isAsc);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(string query, ContactFilterByEnum? filterField, ContactSortByEnum? sortBy, int? take, int? skip)
        {
            return await _contactRepository.GetAllAsync(query, filterField, sortBy, take, skip);
        }
    }
}