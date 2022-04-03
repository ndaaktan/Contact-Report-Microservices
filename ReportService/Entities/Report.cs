using ReportService.Data.Concrete;
using System;

namespace ReportService.Entities
{
        public class Report : BaseEntity
        {
            public DateTime Date { get; set; }
            public ReportStatusType ReportStat { get; set; }
        }
}
