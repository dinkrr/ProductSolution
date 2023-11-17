using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Infrastructure
{
    public class BaseCatalogRepository<T> : ICatalogRepository<T> where T : BaseEntity
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        protected BaseCatalogRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }

        public void Add(T entity)
        {
            _dbSet.Add(entity);
            _dbContext.SaveChangesAsync();
        }

        public T Get(int id)
        {
            return _dbSet.Find(id);
        }

        public IList<T> GetAll()
        {
            return _dbSet.ToList();
        }

        public T Update(T entity)
        {
            _dbSet.Update(entity);
            _dbContext.SaveChanges();
            return entity;
        }

        public bool Delete(int id)
        {
            var entityToRemove = _dbSet.Find(id);
            if (entityToRemove != null)
            {
                _dbSet.Remove(entityToRemove);
                _dbContext.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
