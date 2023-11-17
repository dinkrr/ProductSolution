using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class ItemRepository : BaseCatalogRepository<Item>
    {
        protected ItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
