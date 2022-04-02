using ContactService.Context;
using ContactService.Data.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ContactService.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ContactDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ContactDbContext context)
        {
            _context = context;
            _entities = _context.Set<T>();

        }
        public void Delete(Guid id)
        {
            if (id == null)
            {
                throw new ArgumentNullException("entity");
            }
            var record = _entities.FirstOrDefault(x => x.Uuid == id);
            _entities.Remove(record);

        }

        public void Delete(List<T> list)
        {
             _entities.RemoveRange(list);
        }

        public T Get(Expression<Func<T, bool>> _predicate)
        {
            return _entities.FirstOrDefault(_predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> _predicate)
        {
            return _entities.Where(_predicate);
        }

        public T Add(T entity)
        {
            if (_entities == null)
            {
                throw new ArgumentNullException("entity");
            }

            return _entities.Add(entity).Entity;
        }

        public bool Any(Expression<Func<T, bool>> _predicate) =>
           _entities.Any(_predicate);


        public void Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            _entities.Update(entity);
            _context.SaveChangesAsync();
        }
    }
}
