using System.Collections.Generic;

namespace CartingService.Entities
{
    public class Cart
    {
        public string Id { get; set; }
        public string SomeProperty { get; set; }
        public List<CartItem> Items { get; set; }
    }
}
