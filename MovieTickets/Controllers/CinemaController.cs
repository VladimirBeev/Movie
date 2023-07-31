using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Cinema;

namespace MovieTickets.Web.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinemaService cinemaService;

        public CinemaController(ICinemaService cinemaService)
        {
            this.cinemaService = cinemaService;
        }

        public async Task<IActionResult> AllCinemas()
        {
            var data = await cinemaService.GetAllCinemasAsync();
            return View(data);
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
        public async Task<IActionResult> Details(int id)
        {
            var cinemaModel = await cinemaService.GetCinemaByIdAsync(id);

            return View(cinemaModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var cinemaDetails = await cinemaService.GetCinemaByIdAsync(id);

            return View(cinemaDetails);
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
