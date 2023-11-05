using CartingService.DataAccess;
using CartingService.Entities;

namespace CartingService.BusinessLogic
{
    public class CartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public Cart GetCart(string cartId)
        {
            return _cartRepository.GetCart(cartId);
        }

        public void AddItemToCart(string cartId, CartItem item)
        {
            _cartRepository.AddItemToCart(cartId, item);
        }

        public void RemoveItemFromCart(string cartId, int itemId)
        {
            _cartRepository.RemoveItemFromCart(cartId, itemId);
        }
    }
}
