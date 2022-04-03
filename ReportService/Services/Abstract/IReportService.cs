using ReportService.Dtos;
using System.Collections.Generic;

namespace ReportService.Services.Abstract
{
    public interface IReportService
    {
        List<GetReportDto> GetReports();
    }
}
