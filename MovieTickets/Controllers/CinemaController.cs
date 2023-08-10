using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Cinema;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    [Authorize]
    public class CinemaController : BaseController
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
            if (User.Role() == "Admin")
            {
                return View();
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Create(CinemasViewModel cinemaModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await cinemaService.AddCinemaAsync(cinemaModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error on Create a Cinema, Please try again");
            }

            TempData[SuccessMessage] = "Create a Cinema Complete";

            return RedirectToAction("AllCinemas");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var detailsModel = await cinemaService.GetCinemaByIdAsync(id);

                if (detailsModel != null)
                {
                    return View(detailsModel);
                }
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Details Cinema, Please try Again";

                return RedirectToAction("AllCinemas");
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
                    var cinemaEdit = await cinemaService.GetCinemaByIdAsync(id);

                    if (cinemaEdit != null)
                    {
                        return View(cinemaEdit);
                    }
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error on Edit Cinema, Please try Again";

                    return RedirectToAction("AllCinemas");
                }

                return View("NotFound");
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CinemasViewModel cinemaModel)
        {
            if (!ModelState.IsValid)
            {
                return View(cinemaModel.Id);
            }

            try
            {
                await cinemaService.UpdateCinemaAsync(cinemaModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error on Create a Cinema, Please try again");
            }

            TempData[SuccessMessage] = "You Edit Cinema Complete";

            return RedirectToAction("AllCinemas");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    await cinemaService.DeleteCinemaAsync(id);
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error on Delete Cinema, Please try Again";

                    return RedirectToAction("AllCinemas");
                }

                TempData[SuccessMessage] = "You Delete Cinema Complete";

                return RedirectToAction("AllCinemas");
            }

            return RedirectToAction("AccessDenied", "Account");
        }
    }
}
