using ReportService.Entities;
using System;

namespace ReportService.Dtos
{
    public class GetReportDto
    {
        public Guid Uuid { get; set; }
        public DateTime Date { get; set; }
        public ReportStatusType ReportStat { get; set; }

        public string ReportStatusText
        {
            get
            {
                return ReportStat.ToString();
            }
        }
    }
}
