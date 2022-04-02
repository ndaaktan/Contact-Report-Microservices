using ContactService.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ContactService.Data.Abstract
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        IEnumerable<T> GetAll(Expression<Func<T, bool>> _predicate);
        T Get(Expression<Func<T, bool>> _predicate);
        T Add(T entity);
        bool Any(Expression<Func<T, bool>> _predicate);
        void Update(T entity);
        void Delete(Guid id);
        void Delete(List<T> list);
    }
}
