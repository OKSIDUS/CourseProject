using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;

namespace UserCollection.WebAPP.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionItemService service;

        public ItemController(ICollectionItemService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> CollectionItems(int id)
        {
            var items = await service.GetAllAsync();
            return View(items);
        }
    }
}
