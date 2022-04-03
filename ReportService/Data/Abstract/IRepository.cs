using ReportService.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ReportService.Data.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetAll(Expression<Func<T, bool>> _predicate);
        T Get(Expression<Func<T, bool>> _predicate);
        T Add(T entity);
        bool Any(Expression<Func<T, bool>> _predicate);
        void Update(T entity);
        void Delete(Guid id);
        void Delete(List<T> list);
    }
}
