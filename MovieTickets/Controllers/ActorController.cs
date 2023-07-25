using Microsoft.AspNetCore.Mvc;

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
        public async Task<IActionResult> Create(AllActorsViewModel actorModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            await actorService.AddActorAsync(actorModel);

            return RedirectToAction("AllActors");
        }
    }
}
