using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPP.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService service;

        public CollectionController(ICollectionService service)
        {
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            var collections = await service.GetAllCollectionsAsync();
            
            return View(collections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var collection = await service.GetCollectionAsync(id);
            return View(collection);
        }

        
        public async Task<IActionResult> UserCollections(string userId = "SomeUser")
        {
            var collections = await service.GetUserCollections(userId);
            return View(collections);
        }
    }
}
