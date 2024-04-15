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
        private readonly ICollectionItemService itemService;

        public CollectionController(ICollectionService service, UserManager<IdentityUser> userManager, ICategoryService categoryService, ICollectionItemService itemService)
        {
            this.service = service;
            this.userManager = userManager;
            this.categoryService = categoryService;
            this.itemService = itemService;
        }

        public async Task<IActionResult> Index()
        {
            var collections = await service.GetFiveBiggestCollectionsAsync();
            var items = await itemService.GetLastAddedItems();
            ViewBag.Items = items;
            return View(collections);
        }

        public async Task<IActionResult> Details(int id)
        {
            var collection = await service.GetCollectionAsync(id);
            return View(collection);
        }

        
        public async Task<IActionResult> UserCollections(string? userId )
        {
            if (string.IsNullOrEmpty(userId))
            {
                var user = await userManager.GetUserAsync(User);
                if (user is null)
                {
                    return RedirectToAction("Index");
                }
                var collections = await service.GetUserCollections(user.Id);
                return View(collections);
            }

            var collectionsForAdmin = await service.GetUserCollections(userId);
            return View(collectionsForAdmin);
            
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

        public async Task<IActionResult> Delete(int id)
        {
            await service.DeleteCollectionAsync(id);
            return RedirectToAction("UserCollections");
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

        [HttpGet]
        public async Task<IActionResult> AllCollections(int pageSize = 10, int pageNumber = 1)
        {
            var user = await userManager.GetUserAsync(User);
            if ( user is not null && await userManager.IsInRoleAsync(user, "admin"))
            {
                var collectionsForAdmin = await service.GetPageOfCollectionForAdmin(pageSize, pageNumber);
                return View(collectionsForAdmin);
            }
            else
            {
                var collectionsForUser = await service.GetPageOfCollectionForUser(pageSize, pageNumber);
                return View(collectionsForUser);
            }
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
