using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Controllers;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Home;

using System.Diagnostics;

namespace MovieTickets.Controllers
{
    [Authorize]
    public class HomeController : BaseController
    {
        private readonly IMovieService movieService;
        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Role() == "Admin")
            {
                return RedirectToAction("Admin", "Home", new { area = "Admin"});
            }
            var threeMovies = await movieService.LastThreeMovies();

            return View(threeMovies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400 || statusCode == 404)
            {
                return View("Error404");
            }
            if (statusCode == 401)
            {
                return View("Error401");
            }
            return View();
        }
    }
}