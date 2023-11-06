using CartingService.Entities;
using LiteDB;
using System.Collections.Generic;
using System.Linq;

namespace CartingService.DataAccess
{
    public class LiteDbCartRepository : ICartRepository
    {
        private const string EntityName = "carts";
        private readonly LiteDatabase _database;
        private readonly ILiteCollection<Cart> _cartsCollection;

        public LiteDbCartRepository(string connectionString)
        {
            _database = new LiteDatabase(connectionString);
            _cartsCollection = _database.GetCollection<Cart>(EntityName);
        }

        public Cart GetCart(string cartId)
        {
            return _cartsCollection.FindOne(Query.EQ("Id", cartId)) ?? new Cart { Id = cartId, Items = new List<CartItem>() };
        }

        public void AddItemToCart(string cartId, CartItem item)
        {
            var cart = GetCart(cartId);
            var existingItem = cart.Items.FirstOrDefault(i => i.Id == item.Id);

            if (existingItem != null)
            {
                existingItem.Quantity += item.Quantity;
            }
            else
            {
                cart.Items.Add(item);
            }

            _cartsCollection.Upsert(cart);
        }

        public void RemoveItemFromCart(string cartId, int itemId)
        {
            var cart = GetCart(cartId);
            var itemToRemove = cart.Items.FirstOrDefault(i => i.Id == itemId);

            if (itemToRemove != null)
            {
                cart.Items.Remove(itemToRemove);
                _cartsCollection.Upsert(cart);
            }
        }
    }
}
