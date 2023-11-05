using CartingService.Entities;

namespace CartingService.DataAccess
{
    public interface ICartRepository
    {
        Cart GetCart(string cartId);
        void AddItemToCart(string cartId, CartItem item);
        void RemoveItemFromCart(string cartId, int itemId);
    }
}
