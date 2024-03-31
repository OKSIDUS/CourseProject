using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using UserCollection.Services.Interfaces;
using UserCollection.WebAPI.Models;
using UserCollection.WebAPP.Hubs;

namespace UserCollection.WebAPP.Controllers
{
    public class CommentController : Controller
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IHubContext<CommentHub> commentHub;
        private readonly ICommentService service;
        private readonly UserManager<IdentityUser> userManager;

        public CommentController(ICommentService service, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor, IHubContext<CommentHub> commentHub)
        {
            this.service = service;
            this.userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            this.commentHub = commentHub;
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment(CommentModel comment)
        {
            if (comment is not null)
            {
                var user = await userManager.GetUserAsync(User);
                comment.Author = user.UserName;
                await service.CreateComment(comment);
                await commentHub.Clients.All.SendAsync("ReceiveComment", comment.Author, comment.Text);
                return RedirectToAction("ItemDetails", "Item", new { id = comment.ItemId });
            }
            string refererUrl = _httpContextAccessor.HttpContext.Request.Headers["Referer"];

            return Redirect(refererUrl);
        }
    }
}
