using ReportService.Data.Abstract;
using ReportService.Dtos;
using ReportService.Entities;
using ReportService.Extensions;
using ReportService.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ReportService.Services.Concrete
{
    public class ReportServices : IReportService
    {
        private readonly IReportRepository _reportRepository;
        public ReportServices(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<Guid> Add(ReportRequestDto report)
        {

            var result = await _reportRepository.Add(report.ConvertToEntity());
            return result;
        }

        public List<GetReportDto> GetReports()
        {

            return _reportRepository.GetAll().Select(x => x.ConvertToDto()).ToList();

        }
    }
}
