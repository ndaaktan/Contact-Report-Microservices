using ReportService.Dtos;
using ReportService.Entities;

namespace ReportService.Extensions
{
    public static class DtoConverter
    {
        public static Report ConvertToEntity(this GetReportDto _dto) =>
           new Report
           {
               Date = _dto.Date,
               ReportStat = _dto.ReportStat,
               Uuid = _dto.Uuid
           };
        public static GetReportDto ConvertToDto(this Report _entity) =>
            new GetReportDto
            {
                Date = _entity.Date,
                ReportStat = _entity.ReportStat,
                Uuid = _entity.Uuid
            };
    }
}
