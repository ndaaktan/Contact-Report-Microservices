using ContactService.Context;
using ContactService.Data.Abstract;
using ContactService.Entities;

namespace ContactService.Data.Concrete
{
    public class ContactInformationRepository : Repository<ContactInformation>, IContactInformationRepository
    {
        private readonly ContactDbContext _Context;

        public ContactInformationRepository(ContactDbContext _context) : base(_context)
        {
            _Context = _context;

        }
     
    }
}
