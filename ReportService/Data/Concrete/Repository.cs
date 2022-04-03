using ReportService.Context;
using ReportService.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ReportService.Data.Concrete
{
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private readonly ReportDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(ReportDbContext context)
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
            _context.SaveChanges();
        }

        public void Delete(List<T> list)
        {
            _entities.RemoveRange(list);
            _context.SaveChanges();

        }

        public T Get(Expression<Func<T, bool>> _predicate)
        {
            return _entities.FirstOrDefault(_predicate);
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }

        public IQueryable<T> GetAll(Expression<Func<T, bool>> _predicate)
        {
            return _entities.Where(_predicate);
        }

        public async Task<Guid> Add(T entity)
        {
            if (_entities == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            _context.Entry(entity).GetDatabaseValues();
            return entity.Uuid;
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
