using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPI.Controllers
{
    public class TagController : Controller
    {
        private readonly ITagService service;

        public TagController(ITagService service)
        {
            this.service = service;
        }

        [HttpGet("/Tag/{id}")]
        public async Task<IActionResult> GetTag(int id)
        {
            var tag = await service.GetTagByIdAsync(id);
            if (tag is null)
            {
                return BadRequest();
            }
            return Ok(tag);
        }

        [HttpGet("/Tag")]
        public async Task<IActionResult> GetAllTags()
        {
            var tags = await service.GetAllAsync();
            return Ok(tags);
        }

        [HttpPost("/Tag/Create")]
        public async Task<IActionResult> AddTag(TagModel tag)
        {
            if (tag is null)
            {
                return BadRequest();
            }

            await service.AddTagAsync(tag);
            return Ok();
        }

        [HttpPost("/Tag/Update")]
        public async Task<IActionResult> UpdateTag(TagModel tag)
        {
            if (tag is null)
            {
                return BadRequest();
            }

            await service.UpdateTagAsync(tag);
            return Ok();
        }

        [HttpDelete("/Tag/Delete/{id}")]
        public async Task<IActionResult> DeleteTag(int id)
        {
            await service.DeleteTagAsync(id);
            return Ok();
        }
    }
}
