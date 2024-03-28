using Humanizer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPP.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService service;
        private readonly UserManager<IdentityUser> userManager;
        private readonly ICategoryService categoryService;

        public CollectionController(ICollectionService service, UserManager<IdentityUser> userManager, ICategoryService categoryService)
        {
            this.service = service;
            this.userManager = userManager;
            this.categoryService = categoryService;
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

        
        public async Task<IActionResult> UserCollections()
        {
            var user = await userManager.GetUserAsync(User);
            var collections = await service.GetUserCollections(user.Id);
            return View(collections);
        }

        public async Task<IActionResult> UserCollection(int id)
        {
            var collection = await service.GetCollectionAsync(id);
            return View(collection);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            var selectListItems = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.SelectListItems = selectListItems;
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

        [Authorize(Policy = "AdminRole")]
        [HttpGet]
        public async Task<IActionResult> AllCollections()
        {
            var collections = await service.GetAllCollectionsAsync();
            return View(collections);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var categories = await categoryService.GetAllCategoriesAsync();

            var selectListItems = categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            }).ToList();

            ViewBag.SelectListItems = selectListItems; 

            var collection = await service.GetCollectionAsync(id);
            return View(collection);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CollectionModel collection)
        {
            if (collection is not null)
            {
                await service.UpdateCollectionAsync(collection);
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
