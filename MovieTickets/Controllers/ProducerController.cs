using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ProducerController : Controller
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
            var allProducers = await producerService.GetAllProducersAsync();

            if (allProducers == null)
            {
                return View("NotFound");
            }

            return View(allProducers);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProducersViewModel producerModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await producerService.AddProducerAsync(producerModel);

            return RedirectToAction("AllProducers");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var producerDetails = await producerService.GetProducerByIdAsync(id);

            if (producerDetails == null)
            {
                return View("NotFound");
            }

            return View(producerDetails);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var producerEdit = await producerService.GetProducerByIdAsync(id);

            if (producerEdit == null)
            {
                return View("NotFound");
            }

            return View(producerEdit);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ProducersViewModel producerModel)
        {
            if (!ModelState.IsValid)
            {
                return View(producerModel.Id);
            }
            await producerService.UpdateProducerAsync(producerModel);

            return RedirectToAction("AllProducers");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await producerService.DeleteProducerAsync(id);

            return RedirectToAction("AllProducers");
        }
    }
}
