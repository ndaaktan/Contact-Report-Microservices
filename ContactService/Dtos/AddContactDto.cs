﻿using System.ComponentModel.DataAnnotations;

namespace ContactService.Dtos
{
    public class AddContactDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Company { get; set; }
    }
}
