using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;

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
    }
}
