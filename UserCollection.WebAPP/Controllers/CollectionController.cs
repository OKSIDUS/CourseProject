using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPP.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService service;
        private readonly UserManager<IdentityUser> userManager;

        public CollectionController(ICollectionService service, UserManager<IdentityUser> userManager)
        {
            this.service = service;
            this.userManager = userManager;
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

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create(CollectionModel collection)
        {
            if (collection is not null)
            {
                var user = await userManager.GetUserAsync(User);
                collection.UserName = user.UserName;
                collection.UserId = user.Id;
                await service.AddCollectionAsync(collection);
                return RedirectToAction("UserCollections");
            }

            return View();
        }
    }
}
