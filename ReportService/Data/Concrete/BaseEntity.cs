using ReportService.Data.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace ReportService.Data.Concrete
{
    public class BaseEntity : IEntity
    {
        [Key]
        [Required]
        public Guid Uuid { get; set; }
    }
}
