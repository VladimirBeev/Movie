using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Producer;

namespace MovieTickets.Web.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerService producerService;

        public ProducerController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        public async Task<IActionResult> AllProducers()
        {
            var data = await producerService.GetAllProducersAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AllProducersViewModel producerModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            await producerService.AddProducerAsync(producerModel);

            return RedirectToAction("AllProducers");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var producerModel = await producerService.GetProducerByIdAsync(id);

            return View(producerModel);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var producerModel = await producerService.GetProducerByIdAsync(id);

            return View(producerModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AllProducersViewModel producerModel)
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
