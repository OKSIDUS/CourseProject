using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPP.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionItemService service;
        private readonly ICollectionService collectionService;

        public ItemController(ICollectionItemService service, ICollectionService collectionService)
        {
            this.service = service;
            this.collectionService = collectionService;
        }

        public async Task<IActionResult> CollectionItems(int id)
        {
            var collectionId = Request.Query["id"];
            ViewBag.CollectionId = id;
            var items = await service.GetAllCollectionItemsAsync(id);
            return View(items);
        }

        public async Task<IActionResult> ItemDetails(int id)
        {
            var item = await service.GetItemByIdAsync(id);
            return View(item);
        }

        [HttpGet]
        public async Task<IActionResult> CreateItem(int id)
        {
            ViewBag.Collection = await collectionService.GetCollectionAsync(id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateItem(ItemModel item)
        {
            if (item is not null)
            {
                
                ViewBag.CollectionId = item.CollectionId;
                item.CreatedDate = DateTime.Now;
                await service.AddItemAsync(item);
                return RedirectToAction("CollectionItems", new { id = item.CollectionId });
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ItemEdit(int id)
        {
            ViewBag.ItemId = id;
            var item = await service.GetItemByIdAsync(id);
            return View(item);
        }

        [HttpPost]
        public async Task<IActionResult> ItemEdit(ItemModel item)
        {
            if (item is not null)
            {
                await service.UpdateItemAsync(item);
                return RedirectToAction("CollectionItems", new { id = item.CollectionId });
            }

            return View();
        }
    }
}
