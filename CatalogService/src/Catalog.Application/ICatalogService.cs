using System.Collections.Generic;

namespace Catalog.Application
{
    public interface ICatalogService<T> where T : class
    {
        T Get(int id);
        IList<T> GetAll();
        void Add(T entity);
        T Update(T entity);
        bool Delete(int id);
    }
}
