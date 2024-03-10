using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }

        [HttpGet("/Category/{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await service.GetCategoryAsync(id);
            if (category is null)
            {
                return BadRequest();
            }

            return Ok(category);
        }

        [HttpGet("/Category")]
        public async Task<IActionResult> GetAll()
        {
            var categories =await service.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpPost("/Category/Create")]
        public async Task<IActionResult> Create(CollectionCategoryModel categoryModel)
        {
            if (categoryModel is null)
            {
                return BadRequest(categoryModel);
            }

            await service.AddCategoryAsync(categoryModel);
            return Ok();
        }

        [HttpDelete("/Category/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteCategoryAsync(id);
            return Ok();
        }

        [HttpPost("/Category/Update")]
        public async Task<IActionResult> Update(CollectionCategoryModel category)
        {
            if (category is null)
            {
                return BadRequest();
            }

            await service.UpdateCategoryAsync(category);
            return Ok();
        }
    }
}
