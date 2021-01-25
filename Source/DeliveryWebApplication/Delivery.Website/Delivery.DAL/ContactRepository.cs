using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delivery.DAL.Contracts;
using Delivery.Models;
using Delivery.Utils.Enum;
using Delivery.Utils.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Delivery.DAL.Repositories
{
    public class ContactRepository : BaseRepository<Contact>, IContactRepository
    {
        public ContactRepository(DeliveryContextFactory context) : base(context) { }

        new public int Create(Contact contact)
        {
            base.Create(contact);
            return contact.Id;
        }

        new public async Task<int> CreateAsync(Contact contact)
        {
            await base.CreateAsync(contact);
            return contact.Id;
        }

        public Contact FindContactByUserId(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Contacts.FirstOrDefault(contact => contact.UserId == id);
            }
        }

        public async Task<Contact> FindContactByUserIdAsync(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                return await context.Contacts.FirstOrDefaultAsync(contact => contact.UserId == id);
            }
        }

        public int CreateContact(Contact contact)
        {
            using (var context = _contextFactory.GetContext())
            {
                var contactModel = context.Contacts.FirstOrDefault(c => c.FirstName.Equals(contact.FirstName) &&
                                                              c.LastName.Equals(contact.LastName) &&
                                                              c.CellPhone.Equals(contact.CellPhone) &&
                                                              c.Address.Equals(contact.Address) &&
                                                              c.Email.Equals(contact.Email));
                return contactModel != null
                    ? contactModel.Id
                    : Create(new Contact
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        CellPhone = contact.CellPhone,
                        Address = contact.Address,
                        Email = contact.Email,
                        UserId = contact.UserId
                    });
            }
        }

        public async Task<int> CreateContactAsync(Contact contact)
        {
            using (var context = _contextFactory.GetContext())
            {
                var contactModel = await context.Contacts.FirstOrDefaultAsync(c => c.FirstName.Equals(contact.FirstName) &&
                                                          c.LastName.Equals(contact.LastName) &&
                                                          c.CellPhone.Equals(contact.CellPhone) &&
                                                          c.Address.Equals(contact.Address) &&
                                                          c.Email.Equals(contact.Email));

                return contactModel != null
                    ? contactModel.Id
                    : await CreateAsync(new Contact
                    {
                        FirstName = contact.FirstName,
                        LastName = contact.LastName,
                        CellPhone = contact.CellPhone,
                        Address = contact.Address,
                        Email = contact.Email,
                        UserId = contact.UserId
                    });
            }
        }

        public IEnumerable<Contact> Sort(IEnumerable<Contact> contacts, string paramName, bool isAsc)
        {
            Func<Contact, string> predicate;
            switch (paramName)
            {
                case "Name":
                    predicate = contact => contact.FirstName;
                    break;
                case "LastName":
                default:
                    predicate = contact => contact.LastName;
                    break;
            }
            return isAsc ? contacts.OrderBy(predicate) : contacts.OrderByDescending(predicate);
        }

        public async Task<IEnumerable<Contact>> GetAllAsync(string query, ContactFilterByEnum? filterField, ContactSortByEnum? sortBy, int? take, int? skip)
        {
            using (var context = _contextFactory.GetContext())
            {
                var result = context.Contacts.AsQueryable();

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
