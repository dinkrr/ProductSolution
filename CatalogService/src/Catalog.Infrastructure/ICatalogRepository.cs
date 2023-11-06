using Catalog.Core.Entities;
using System.Collections.Generic;

namespace Catalog.Infrastructure
{
    public interface ICatalogRepository<T> where T : BaseEntity
    {
        T Get(int id);
        IList<T> GetAll();
        void Add(T item);
        bool Delete(int id);
        T Update(T item);
    }
}