using ContactService.Data.Concrete;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContactService.Entities
{
    public class Contact : BaseEntity
    {

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Company { get; set; }
        public List<ContactInformation> ContactInformations { get; set; } = new List<ContactInformation>();
    }
}
