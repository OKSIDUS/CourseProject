using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UserCollection.WebAPP.Controllers
{
    [Authorize(Roles ="admin")]
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
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

        public async Task<IActionResult> BlockUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            user.LockoutEnd = DateTime.Now.AddYears(100);
            await userManager.UpdateAsync(user);
            return RedirectToAction("Users");
        }

        public async Task<IActionResult> UnlockUser(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            user.LockoutEnd = DateTime.Now.AddYears(-1);
            await userManager.UpdateAsync(user);
            return RedirectToAction("Users");

        }

        public async Task<IActionResult> SetAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (!await userManager.IsInRoleAsync(user, "admin"))
            {
                await userManager.AddToRoleAsync(user, "admin");
                await userManager.UpdateAsync(user);
            }

            return RedirectToAction("Users");
        }

        public async Task<IActionResult> UnsetAdmin(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if(await userManager.IsInRoleAsync(user, "admin"))
            {
                await userManager.RemoveFromRoleAsync(user, "admin");
                await userManager.UpdateAsync(user);
            }

            var authorizeUser = await userManager.GetUserAsync(User);
            if(user.Id == authorizeUser.Id)
            {
                await signInManager.SignOutAsync();
                return RedirectToAction("Index", "Collection");
            }
            return RedirectToAction("Users");
        }
    } 
}
