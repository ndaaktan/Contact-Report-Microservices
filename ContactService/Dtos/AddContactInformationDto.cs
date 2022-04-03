using ContactService.Entities;
using System;
using System.Text.Json.Serialization;

namespace ContactService.Dtos
{
    public class AddContactInformationDto
    {
        public ContactInformationType ContactInformationType { get; set; }
        public Guid ContactUuid { get; set; }
        public string Information { get; set; }
    }
   
}
