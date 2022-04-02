using System.Collections.Generic;

namespace ContactService.Dtos
{
    public class ContactInformationDto
    {
        public ContactDto Contact { get; set; }
        public List<object> ContactInfoList { get; set; }
    }
}
