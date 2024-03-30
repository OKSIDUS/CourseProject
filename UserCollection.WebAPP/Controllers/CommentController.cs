using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;

namespace UserCollection.WebAPP.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICommentService service;
        private readonly UserManager<IdentityUser> userManager;

        public CommentController(ICommentService service, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            this.service = service;
            this.userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentModel comment)
        {
            if (comment is not null)
            {
                var user = await userManager.GetUserAsync(User);
                comment.Author = user.UserName;
                await service.CreateComment(comment);
                return RedirectToAction("ItemDetails", "Item", new { id = comment.ItemId });
            }
            string refererUrl = _httpContextAccessor.HttpContext.Request.Headers["Referer"];

            return Redirect(refererUrl);
        }
    }
}
