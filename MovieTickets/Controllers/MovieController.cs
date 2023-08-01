using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Movie;

namespace MovieTickets.Web.Controllers
{
	public class MovieController : Controller
	{
		private readonly IMovieService movieService;

		public MovieController(IMovieService movieService)
		{
			this.movieService = movieService;
		}

		[HttpGet]
		public async Task<IActionResult> AllMovies()
		{
			IEnumerable<AllMoviesViewModel> data = await movieService.GetAllMoviesAsync();
			return View(data);
		}

		[HttpGet]
		public async Task<IActionResult> Details(int id)
		{
			Movie movie = await movieService.GetMovieByIdAsync(id);
			return View(movie);
		}

		[HttpGet]
		public async Task<IActionResult> Create()
		{
			var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

			ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
			ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Create(NewMovie newMovie)
		{
			if (!ModelState.IsValid)
			{
				var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

				ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Title");
				ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
				ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

				return View(newMovie);
			}

			await movieService.AddMovieAsync(newMovie);

			return RedirectToAction("AllMovies");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			var movieDetails = await movieService.GetMovieByIdAsync(id);

			if (movieDetails == null)
			{
				return View("Not Found");
			}

			var response = new NewMovie();

			response.Id = movieDetails.Id;
			response.Title = movieDetails.Title;
			response.Description = movieDetails.Description;
			response.Price = movieDetails.Price;
			response.StartDate = movieDetails.StartDate;
			response.EndDate = movieDetails.EndDate;
			response.ImageUrl = movieDetails.ImageUrl;
			response.MovieCategory = movieDetails.MovieCategory;
			response.CinemaId = movieDetails.CinemaId;
			response.ProducerId = movieDetails.ProducerId;
			response.ActorIds = movieDetails.ActorMovies.Select(n => n.ActorId).ToList();

			var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

			ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
			ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
			ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

			return View(response);
		}

		[HttpPost]

		public async Task<IActionResult> Edit(int id, NewMovie movieViewModel)
		{
			if (id != movieViewModel.Id)
			{
				return View("NotFound");
			}

			if (!ModelState.IsValid)
			{
				var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

				ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
				ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
				ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

				return View(movieViewModel);
			}

			await movieService.UpdateMovieAsync(movieViewModel);

			return RedirectToAction("AllMovies");
		}
	}
}
