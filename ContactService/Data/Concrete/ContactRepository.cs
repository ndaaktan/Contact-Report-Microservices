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

        public List<ContactInformationDto> GetContactInfo(Guid id)
        {
            return null;
        }
    }
}
