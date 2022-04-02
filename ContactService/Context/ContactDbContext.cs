using ContactService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ContactService.Context
{
    public class ContactDbContext : DbContext
    {
        public ContactDbContext(DbContextOptions<ContactDbContext> options) : base(options)
        {

        }
        public DbSet<Contact> Contacts { get; private set; }
        public DbSet<ContactInformation> ContactInformations { get; private set; }
    }
}
