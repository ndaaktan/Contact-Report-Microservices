using System;

namespace ReportService.Data.Abstract
{
    public interface IEntity
    {
        public Guid Uuid { get; set; }
    }
}
