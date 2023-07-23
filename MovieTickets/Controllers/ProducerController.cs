using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;

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
    }
}
