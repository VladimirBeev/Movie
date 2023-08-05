using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Home;

using System.Diagnostics;

namespace MovieTickets.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieService movieService;
        public HomeController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        public async Task<IActionResult> Index()
        {
            var threeMovies = await movieService.LastThreeMovies();

            return View(threeMovies);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel
            { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}