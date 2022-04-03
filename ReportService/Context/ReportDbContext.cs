using Microsoft.EntityFrameworkCore;
using ReportService.Entities;

namespace ReportService.Context
{
    public class ReportDbContext : DbContext
    {
        public ReportDbContext(DbContextOptions<ReportDbContext> options) : base(options)
        {

        }
        public DbSet<Report> Reports { get; private set; }
    }
}
