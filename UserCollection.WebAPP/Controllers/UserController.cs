using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserCollection.WebAPP.Controllers
{
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        public UserController(UserManager<IdentityUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IActionResult> Users()
        {
            var users = await userManager.Users.ToListAsync();
            ViewBag.Users = users;
            return View();
        }

        public async Task<IActionResult> UserDetails(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            ViewBag.User = user;
            return View(user);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            await userManager.DeleteAsync(user);
            return RedirectToAction("Users");
        }
    }
}
