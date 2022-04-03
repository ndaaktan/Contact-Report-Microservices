using ContactService.Context;
using ContactService.Data.Abstract;
using ContactService.Dtos;
using ContactService.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactService.Data.Concrete
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ContactDbContext _Context;

        public ContactRepository(ContactDbContext _context) : base(_context)
        {
            _Context = _context;
        }

        public List<ContactInformation> GetContactWithcontactInformation(Guid id)
        {
            var result = _Context.Contacts.Where(x => x.Uuid == id).
                  Join(_Context.ContactInformations, x => x.Uuid, y => y.ContactUuid,
                      (x, y) => new
                      {
                          Contact = x,
                          Information = y,
                      }).Select(x => new ContactInformation
                      {
                          Contact = x.Contact,
                          Information = x.Information.Information,
                          ContactInformationType = x.Information.ContactInformationType,
                          Uuid = x.Information.Uuid,
                          ContactUuid = x.Contact.Uuid
                      }).
                   ToList();
            return result;
        }
    }
}
