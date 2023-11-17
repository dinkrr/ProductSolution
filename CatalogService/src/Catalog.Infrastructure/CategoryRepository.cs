using Catalog.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Infrastructure
{
    public class CategoryRepository : BaseCatalogRepository<Category>
    {
        protected CategoryRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
