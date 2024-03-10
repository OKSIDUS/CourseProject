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

        public IActionResult Index()
        {
            return View();
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
    }
}
