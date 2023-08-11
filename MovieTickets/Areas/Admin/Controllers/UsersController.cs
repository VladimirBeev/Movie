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
        private readonly MovieDbContext movieDbContext;
        public UsersController(MovieDbContext movieDbContext)
        {
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
