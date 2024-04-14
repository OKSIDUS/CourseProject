using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPI.Controllers
{
    public class CollectionController : Controller
    {
        private readonly ICollectionService service;

        public CollectionController(ICollectionService service)
        {
            this.service = service;
        }

        [HttpGet("/Collection/{id}")]
        public async Task<IActionResult> GetCollection(int id)
        {
            var collection = await service.GetCollectionAsync(id);
            if (collection is null)
            {
                return BadRequest();
            }

            return Ok(collection);
        }

        [HttpPost("/Collection/Create")]
        public async Task<IActionResult> CreateCollection([FromBody] CollectionModel collection)
        {
            if (collection is null)
            {
                return BadRequest();
            }

            await service.AddCollectionAsync(collection);
            return Ok();
        }

        [HttpGet("/Collection")]
        public async Task<IActionResult> GetAllCollections()
        {
            var collections = await service.GetAllCollectionsAsync();
            return Ok(collections);
        }

        [HttpPost("/Collection/Update")]
        public async Task<IActionResult> UpdateCollection([FromBody] CollectionModel collection)
        {
            if (collection is null)
            {
                return BadRequest();
            }

            await service.UpdateCollectionAsync(collection);
            return Ok();
        }

        [HttpDelete("/Collection/Delete/{id}")]
        public async Task<IActionResult> DeleteCollection(int id)
        {
            await service.DeleteCollectionAsync(id);
            return Ok();
        }

        [HttpGet("/Collection/user={userId}")]
        public async Task<IActionResult> GetUserCollections(string userId)
        {
            var collections = await service.GetUserCollections(userId);
            return Ok(collections);
        }

        [HttpGet("/Collection/FiveBiggest")]
        public async Task<IActionResult> GetFiveBiggestCollections()
        {
            var collections = await service.GetFiveBiggestCollectionsAsync();
            if (collections.Count() == 5)
            {

            }
            return Ok(collections);
        }

        [HttpGet("/Collection/page={pageNumber}/size={pageSize}")]
        public async Task<IActionResult> GetPageOfCollectionForUser(int pageNumber, int pageSize)
        {
            var collection = await service.GetPageOfCollectionForUser(pageSize, pageNumber);
            return Ok(collection);
        }
    }
}
