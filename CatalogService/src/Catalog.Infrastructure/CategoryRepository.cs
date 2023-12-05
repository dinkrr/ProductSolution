using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class CategoryRepository : BaseCatalogRepository<Category>
    {
        public CategoryRepository(CatalogDbContext dbContext) : base(dbContext)
        {
        }
    }
}
