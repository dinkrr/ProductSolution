using CartingService.BusinessLogic;
using CartingService.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Carting.Api.Controllers
{
    [ApiController]
    [ApiVersion("2.0")]
    [Route("v{version:apiVersion}/cart")]
    public class CartControllerV2 : ControllerBase
    {
        private readonly CartService _cartService;

        public CartControllerV2(CartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("getCartInfoV2")]
        public IActionResult GetCartInfoV2(string id)
        {
            var cart = _cartService.GetCart(id);
            return Ok(cart.Items.ToList());
        }

        [HttpPost("addItemV2")]
        public IActionResult AddItemV2(string id, CartItem item)
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
        
        [HttpDelete("deleteItemV2")]
        public IActionResult DeleteItemV2(string cartId, int itemid)
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