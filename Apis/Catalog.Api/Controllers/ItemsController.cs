using Catalog.Application;
using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/items")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly ICatalogService<Item> _itemService;

        public ItemsController(ICatalogService<Item> itemService)
        {
            _itemService = itemService;
        }

        [HttpGet("/items")]
        public IActionResult GetAllItems()
        {
            var items = _itemService.GetAll();
            return Ok(items);
        }

        [HttpPost("/items")]
        public IActionResult CreateItem([FromBody] Item item)
        {
            try
            {
                _itemService.Add(item);
                return Created($"/items/{item.Id}", item);
            }
            catch (NameExceedsLengthLimitException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/items")]
        public IActionResult UpdateItem([FromBody] Item itemToUpdate)
        {
            var item = _itemService.Get(itemToUpdate.Id);
            if (item is null)
            {
                return NotFound();
            }
            var updatedItem = _itemService.Update(item);
            return Ok(updatedItem);
        }
        
        [HttpDelete("/items/id")]
        public IActionResult DeleteItem(int itemId)
        {
            return _itemService.Delete(itemId) ? Ok() : NotFound();
        }
    }
}