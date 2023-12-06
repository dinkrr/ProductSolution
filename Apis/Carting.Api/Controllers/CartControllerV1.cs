using CartingService.BusinessLogic;
using CartingService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/cart")]
    public class CartControllerV1 : ControllerBase
    {
        private readonly CartService _cartService;

        public CartControllerV1(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getCartInfo")]
        public IActionResult GetCartInfo(string id)
        {
            var cart = _cartService.GetCart(id);
            return Ok(cart);
        }

        [HttpPost("addItem")]
        public IActionResult AddItem(string id, CartItem item)
        {
            try
            {
                var cart = _cartService.GetCart(id);
                if (cart != null)
                {
                    _cartService.AddItemToCart(id, item);
                    return Ok(item);
                }
                return BadRequest("Cart Does not exist");
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
        
        [HttpDelete("deleteItem")]
        public IActionResult DeleteItem(string cartId, int itemid)
        {
            try
            {
                _cartService.RemoveItemFromCart(cartId, itemid);
                return Ok();
            }
            catch (Exception ex) 
            { 
                return BadRequest(ex.Message);
            }
        }
    }
}