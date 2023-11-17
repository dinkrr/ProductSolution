using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Catalog.Infrastructure;

namespace Catalog.Application
{
    public class ItemService : BaseCatalogService<Item>
    {
        private readonly ICatalogRepository<Item> _repository;

        public ItemService(ICatalogRepository<Item> repository) : base(repository)
        {
            _repository = repository;
        }

        public override void Add(Item item)
        {
            if (string.IsNullOrEmpty(item.Name) || item.Name.Length > 50)
            {
                throw new NameExceedsLengthLimitException("Item name exceeds the limit of 50");
            }
            _repository.Add(item);
        }
    }
}
