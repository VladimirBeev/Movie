using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllCinemas()
        {
            var allCinemas = await cinemaService.GetAllCinemasAsync();

            if (allCinemas == null)
            {
                return View("NotFound");
            }

            return View(allCinemas);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemasViewModel cinemaModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await cinemaService.AddCinemaAsync(cinemaModel);

            return RedirectToAction("AllCinemas");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var detailsModel = await cinemaService.GetCinemaByIdAsync(id);

            if (detailsModel == null)
            {
                return View("NotFound");
            }

            return View(detailsModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var cinemaEdit = await cinemaService.GetCinemaByIdAsync(id);

            if (cinemaEdit == null)
            {
                return View("NotFound");
            }

            return View(cinemaEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CinemasViewModel cinemaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaModel.Id);
            }
            await cinemaService.UpdateCinemaAsync(cinemaModel);

            return RedirectToAction("AllCinemas");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await cinemaService.DeleteCinemaAsync(id);

            return RedirectToAction("AllCinemas");
        }
    }
}
