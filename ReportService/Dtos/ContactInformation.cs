using ReportService.Entities;
using System;

namespace ReportService.Dtos
{
    public class ContactInformation
    {
        public Guid Uuid { get; set; }
        public ContactInformationType ContactInformationType { get; set; }
        public string Information { get; set; }
        public Guid ContactUuid { get; set; }
        public string InformationType
        {
            get
            {
                return ContactInformationType.ToString();
            }
        }
    }
}
