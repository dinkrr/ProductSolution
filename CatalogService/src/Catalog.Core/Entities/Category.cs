namespace Catalog.Core.Entities
{
    public class Category : BaseEntity
    {
        public int? ParentCategoryId { get; set; }
    }
}
