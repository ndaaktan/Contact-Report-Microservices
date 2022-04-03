using ReportService.Dtos;
using ReportService.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ReportService.Services.Abstract
{
    public interface IReportService
    {
        List<GetReportDto> GetReports();
        Task<Guid> Add(ReportRequestDto report);
    }
}
