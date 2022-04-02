using System;

namespace ContactService.Data.Abstract
{
    public interface IEntity
    {
        public Guid Uuid { get; set; }
    }
}
