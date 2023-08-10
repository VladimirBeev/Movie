using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Services.Data.Models.Movie;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Movie;

using System.Net;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    [Authorize]
    public class MovieController : BaseController
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
            try
            {
                var allMovies = await movieService.GetAllMoviesAsync();

                if (allMovies != null)
                {
                    return View(allMovies);
                }

                return View("NotFound");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Movies, Please try again";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

                    ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
                    ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
                    ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

                    return View();
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error on Create Movie, Please try again";

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("AccessDenied", "Account");
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

            try
            {
                await movieService.AddMovieAsync(movieModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Create a Movie. Please try again.");

                return RedirectToAction("Index", "Home");

            }

            TempData[SuccessMessage] = "Create Movie Complete";

            return RedirectToAction("AllMovies");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var movieDetails = await movieService.GetMovieByIdAsync(id);

                if (movieDetails != null)
                {
                    return View(movieDetails);

                }
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Details Movie, Please try again";

                return RedirectToAction("Index", "Home");
            }

            return View("NotFound");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    var movieToEdit = await movieService.GetNewMovieByIdAsync(id);

                    if (movieToEdit == null)
                    {
                        return View("Not Found");
                    }

                    //var modelToAdd = new NewMovie();

                    //modelToAdd.Id = movieToEdit.Id;
                    //modelToAdd.Title = WebUtility.HtmlDecode(movieToEdit.Title);
                    //modelToAdd.Description = WebUtility.HtmlDecode(movieToEdit.Description);
                    //modelToAdd.Price = movieToEdit.Price;
                    //modelToAdd.StartDate = (DateTime)movieToEdit.StartDate!;
                    //modelToAdd.EndDate = (DateTime)movieToEdit.EndDate!;
                    //modelToAdd.ImageUrl = WebUtility.UrlDecode(movieToEdit.ImageUrl);
                    //modelToAdd.MovieCategory = movieToEdit.MovieCategory;
                    //modelToAdd.CinemaId = movieToEdit.CinemaId;
                    //modelToAdd.ProducerId = movieToEdit.ProducerId;
                    //modelToAdd.ActorIds = movieToEdit.ActorMovies.Select(n => n.ActorId).ToList();

                    var movieDropDownValues = await movieService.GetNewMovieDropDownAsync();

                    ViewBag.Cinemas = new SelectList(movieDropDownValues.Cinemas, "Id", "Name");
                    ViewBag.Producers = new SelectList(movieDropDownValues.Producers, "Id", "Name");
                    ViewBag.Actors = new SelectList(movieDropDownValues.Actors, "Id", "Name");

                    return View(movieToEdit);
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error on Details Movie, Please try again";

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("AccessDenied", "Account");
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

            try
            {
                await movieService.UpdateMovieAsync(movieViewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Create a Movie. Please try again.");

                return RedirectToAction("Index", "Home");
            }

            TempData[SuccessMessage] = "Edit Movie Complete";

            return RedirectToAction("AllMovies");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Filter([FromQuery] AllMoviesQueryModel queryModel)
        {
            try
            {
                AllMoviesFilteredAndPagedServiceModel serviceModel = await movieService.AllAsync(queryModel);

                queryModel.AllMoviesViewModels = serviceModel.Movies;
                queryModel.TotalMovies = serviceModel.TotalMoviesCount;

                return View(queryModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Filter Movie, Please try again";

                return RedirectToAction("Index", "Home");
            }

        }
    }
}
