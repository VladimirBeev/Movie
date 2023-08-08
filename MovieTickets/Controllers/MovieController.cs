using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Movie;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MovieController : Controller
    {
        private readonly IMovieService movieService;

        public MovieController(IMovieService movieService)
        {
            this.movieService = movieService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllMovies()
        {
            var allMovies = await movieService.GetAllMoviesAsync();

            if (allMovies == null)
            {
                return View("NotFound");
            }

            return View(allMovies);
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
        public async Task<IActionResult> Create(NewMovie movieModel)
        {
            if (!ModelState.IsValid)
            {
                var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

                ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
                ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

                return View(movieModel);
            }

            await movieService.AddMovieAsync(movieModel);

            return RedirectToAction("AllMovies");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var movieDetails = await movieService.GetMovieByIdAsync(id);

            if (movieDetails == null)
            {
                return View("NotFound");
            }

            return View(movieDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var movieToEdit = await movieService.GetMovieByIdAsync(id);

            if (movieToEdit == null)
            {
                return View("Not Found");
            }

            var modelToAdd = new NewMovie();

            modelToAdd.Id = movieToEdit.Id;
            modelToAdd.Title = movieToEdit.Title;
            modelToAdd.Description = movieToEdit.Description;
            modelToAdd.Price = movieToEdit.Price;
            modelToAdd.StartDate = (DateTime)movieToEdit.StartDate;
            modelToAdd.EndDate = (DateTime)movieToEdit.EndDate;
            modelToAdd.ImageUrl = movieToEdit.ImageUrl;
            modelToAdd.MovieCategory = movieToEdit.MovieCategory;
            modelToAdd.CinemaId = movieToEdit.CinemaId;
            modelToAdd.ProducerId = movieToEdit.ProducerId;
            modelToAdd.ActorIds = movieToEdit.ActorMovies.Select(n => n.ActorId).ToList();

            var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

            ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
            ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

            return View(modelToAdd);
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

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMovies = await movieService.GetAllMoviesAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                var filteredResultNew = allMovies.Where(n => string.Equals(n.Title, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("AllMovies", filteredResultNew);
            }

            return View("AllMovies", allMovies);
        }
    }
}
