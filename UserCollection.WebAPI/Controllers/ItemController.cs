using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPI.Controllers
{
    public class ItemController : Controller
    {
        private readonly ICollectionItemService service;

        public ItemController(ICollectionItemService service)
        {
            this.service = service;
        }

        [HttpPost("/Item/Create")]
        public async Task<IActionResult> CreateItem(ItemModel item)
        {
            if (item is null)
            {
                return BadRequest();
            }

            await service.AddItemAsync(item);
            return Ok();
        }

        [HttpGet("/Item/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {
            var item = await service.GetItemByIdAsync(id);
            if (item is null)
            {
                return BadRequest();
            }

            return Ok(item);
        }

        [HttpGet("/Item")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await service.GetAllAsync();
            return Ok(items);
        }

        [HttpPost("/item/Update")]
        public async Task<IActionResult> UpdateItem(ItemModel item)
        {
            if (item is null)
            {
                return BadRequest();
            }

            await service.UpdateItemAsync(item);
            return Ok();
        }

        [HttpDelete("/Item/Delete/{id}")]
        public async Task<IActionResult> DeleteItem(int id)
        {
            await service.DeleteItemAsync(id);
            return Ok();
        }
    }
}
