using Catalog.Core.Entities;
using Catalog.Infrastructure;
using System.Collections.Generic;

namespace Catalog.Application
{
    public abstract class BaseCatalogService<T> : ICatalogService<T> where T : BaseEntity
    {
        private readonly ICatalogRepository<T> _catalogRepository;

        public BaseCatalogService(ICatalogRepository<T> catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public abstract void Add(T entity);

        public bool Delete(int id)
        {
            return _catalogRepository.Delete(id);
        }

        public T Get(int id)
        {
            return _catalogRepository.Get(id);
        }

        public IList<T> GetAll()
        {
            return _catalogRepository.GetAll();
        }

        public T Update(T entity)
        {
            return _catalogRepository.Update(entity);
        }
    }
}
