using ReportService.Context;
using ReportService.Data.Abstract;
using ReportService.Entities;

namespace ReportService.Data.Concrete
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(ReportDbContext context) : base(context)
        {
        }
    }
}
