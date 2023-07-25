using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;

namespace MovieTickets.Web.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
		{
			this.movieService = movieService;
		}

		public async Task<IActionResult> AllMovies()
		{
			var data = await movieService.GetAllMoviesAsync();
			return View(data);
		}
	}
}
