using Catalog.Application;
using Catalog.Core.Entities;
using Catalog.Core.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CatalogService.Api.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatalogService<Category> _categoryService;

        public CategoriesController(ICatalogService<Category> categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("/categories")]
        public IActionResult GetAllCategories()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpPost("/categories")]
        public IActionResult CreateCategory([FromBody] Category category)
        {
            try
            {
                _categoryService.Add(category);
                return Created($"/categories/{category.Id}", category);
            }
            catch (NameExceedsLengthLimitException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/categories")]
        public IActionResult UpdateCategory([FromBody] Category categoryToUpdate)
        {
            var category = _categoryService.Get(categoryToUpdate.Id);
            if (category is null)
            {
                return NotFound();
            }
            var updatedCategory = _categoryService.Update(category);
            return Ok(updatedCategory);
        }

        [HttpDelete("/categories/id")]
        public IActionResult DeleteCategory(int categoryId)
        {
            return _categoryService.Delete(categoryId) ? Ok() : NotFound();
        }
    }
}