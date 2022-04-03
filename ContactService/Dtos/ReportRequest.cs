using System;

namespace ContactService.Dtos
{
    public class ReportRequest
    {
        public ReportStatusType Status { get; set; }
        public DateTime Date { get; set; }
    }
    public enum ReportStatusType
    {
        Preparing,
        Completed
    }
}
