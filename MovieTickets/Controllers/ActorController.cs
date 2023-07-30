using Microsoft.AspNetCore.Mvc;

using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.ViewModels.Actor;

namespace MovieTickets.Web.Controllers
{
	public class ActorController : Controller
    {
        private readonly IActorService actorService;

		public ActorController(IActorService actorService)
		{
			this.actorService = actorService;
		}

        [HttpGet]
		public async Task<IActionResult> AllActors()
        {
            var data = await actorService.GetAllActorsAsync();
            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel actorModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            await actorService.AddActorAsync(actorModel);

            return RedirectToAction("AllActors");
        }

        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var actorModel = await actorService.GetActorByIdAsync(id);

            return View(actorModel);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {

            var actorDetails = await actorService.GetActorByIdAsync(id);

            return View(actorDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model.Id);
            }
            await actorService.UpdateActorAsync(model);
            return RedirectToAction("AllActors");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await actorService.DeleteActorAsync(id);
            return RedirectToAction("AllActors");
        }
    }
}
