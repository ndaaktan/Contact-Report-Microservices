using ContactService.Data.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace ContactService.Data.Concrete
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Required]
        public Guid Uuid { get ; set ; }
    }
}
