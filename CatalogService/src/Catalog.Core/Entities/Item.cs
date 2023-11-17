namespace Catalog.Core.Entities
{
    public class Item : BaseEntity
    {
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int Amount { get; set; }
    }
}
