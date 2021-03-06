using ContactService.Entities;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ContactService.Dtos
{
    public class ContactInformationDto
    {
        public Guid Uuid { get; set; }
        public ContactInformationType ContactInformationType { get; set; }
        public Guid ContactUuid { get; set; }
        public string Information { get; set; }
    }
}
