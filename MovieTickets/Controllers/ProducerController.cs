using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Producer;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    [Authorize]
    public class ProducerController : BaseController
    {
        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllProducers()
        {
            try
            {
                var allProducers = await producerService.GetAllProducersAsync();

                if (allProducers != null)
                {
                    return View(allProducers);
                }
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occurred on Producers, Please try again";

                return RedirectToAction("Index","Home");
            }

            return View("NotFound");

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
        public async Task<IActionResult> Create(ProducersViewModel producerModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                await producerService.AddProducerAsync(producerModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Create a Producer. Please try again.");

                return RedirectToAction("Index", "Home");
            }

            TempData[SuccessMessage] = "Create Producer Complete";

            return RedirectToAction("AllProducers");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var producerDetails = await producerService.GetProducerByIdAsync(id);

                if (producerDetails == null)
                {
                    return View("NotFound");
                }

                return View(producerDetails);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error occurred on Producers Details, Please try again";

                return RedirectToAction("Index", "Home");
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    var producerEdit = await producerService.GetProducerByIdAsync(id);

                    if (producerEdit == null)
                    {
                        return View("NotFound");
                    }

                    return View(producerEdit);
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error occurred on Producers Details, Please try again";

                    return RedirectToAction("Index", "Home");
                }
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProducersViewModel producerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(producerModel.Id);
            }

            try
            {
                await producerService.UpdateProducerAsync(producerModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Edit a Producer. Please try again.");

                return RedirectToAction("Index", "Home");
            }

            TempData[SuccessMessage] = "Successfully Edit an Producer";

            return RedirectToAction("AllProducers");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    await producerService.DeleteProducerAsync(id);
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error occurred on Producers Details, Please try again";

                    return RedirectToAction("Index", "Home");
                }

                TempData[SuccessMessage] = "Successfully Delete an Producer";

                return RedirectToAction("AllProducers");
            }

            return RedirectToAction("AccessDenied", "Account");
        }
    }
}
