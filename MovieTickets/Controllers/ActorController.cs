using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;

namespace MovieTickets.Web.Controllers
{
	public class ActorController : Controller
    {
        private readonly IActorService actorService;

		public ActorController(IActorService actorService)
		{
			this.actorService = actorService;
		}

		public async Task<IActionResult> AllActors()
        {
            var data = await actorService.GetAllActorsAsync();
            return View(data);
        }
    }
}
