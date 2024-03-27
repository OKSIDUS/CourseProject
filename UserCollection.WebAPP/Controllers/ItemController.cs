using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

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

        public async Task<IActionResult> ItemDetails(int id)
        {
            var item = await service.GetItemByIdAsync(id);
            return View(item);
        }

        [HttpGet]
        public IActionResult CreateItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemModel item)
        {
            if (item is not null)
            {
                await service.AddItemAsync(item);
                return RedirectToAction("CollectionItems");
            }

            return View();
        }
    }
}
