using ReportService.Data.Abstract;
using ReportService.Dtos;
using ReportService.Extensions;
using ReportService.Services.Abstract;
using System.Collections.Generic;
using System.Linq;

namespace ReportService.Services.Concrete
{
    public class ReportServices : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public List<GetReportDto> GetReports()
        {

            return _reportRepository.GetAll().Select(x => x.ConvertToDto()).ToList();

        }
    }
}
