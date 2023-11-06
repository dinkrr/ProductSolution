using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Catalog.Infrastructure;

namespace Catalog.Application
{
    public class CategoryService : BaseCatalogService<Category>
    {
        private readonly ICatalogRepository<Category> _repository;

        public CategoryService(ICatalogRepository<Category> repository) : base(repository)
        {
            _repository = repository;
        }

        public override void Add(Category category)
        {
            if (string.IsNullOrEmpty(category.Name) || category.Name.Length > 50)
            {
                throw new NameExceedsLengthLimitException("Category name exceeds the limit of 50");
            }
            _repository.Add(category);
        }
    }
}
