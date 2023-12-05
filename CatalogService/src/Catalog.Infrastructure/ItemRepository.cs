using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class ItemRepository : BaseCatalogRepository<Item>
    {
        public ItemRepository(CatalogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
