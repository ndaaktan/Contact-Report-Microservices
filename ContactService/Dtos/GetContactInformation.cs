using ContactService.Entities;
using System;

namespace ContactService.Dtos
{
    public class GetContactInformation
    {
        public Guid Uuid { get; set; }
        public ContactInformationType ContactInformationType { get; set; }
        public string Information { get; set; }
        public Guid ContactUuid { get; set; }
        public string InformationType { get; set; }
    }
}
