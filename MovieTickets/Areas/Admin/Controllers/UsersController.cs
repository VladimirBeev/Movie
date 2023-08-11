using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Web.Areas.Admin.Controllers;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    public class UsersController : BaseAdminController
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly MovieDbContext movieDbContext;
        public UsersController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MovieDbContext movieDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.movieDbContext = movieDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> AllUsers()
        {
            try
            {
                var users = await movieDbContext.Users.ToListAsync();

                return View(users);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Get Users action make an Error";

                return RedirectToAction("Index","Home");
            }
           
        }
    }
}
