using System;

namespace ContactService.Dtos
{
    public class ContactDto
    {
        public Guid Uuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
