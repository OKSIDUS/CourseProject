using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;

namespace UserCollection.WebAPP.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService service;
        public CategoryController(ICategoryService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await service.GetAllCategoriesAsync();
            return View(categories);
        }
    }
}
