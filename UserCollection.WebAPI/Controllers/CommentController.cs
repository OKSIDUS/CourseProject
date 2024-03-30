using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPI.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService service;

        public CommentController(ICommentService service)
        {
            this.service = service;
        }

        [HttpPost("/Comment/Create")]
        public async Task<IActionResult> CreateComment([FromBody] CommentModel comment)
        {
            if (comment is null)
            {
                return BadRequest();
            }

            await service.CreateComment(comment);
            return Ok();
        }

        [HttpGet("/Comment/{id}")]
        public async Task<IActionResult> GetItemComments(int id)
        {
            var comments = await service.GetAllItemsComments(id);
            return Ok(comments);
        }
    }
}
