using Microsoft.AspNetCore.Mvc;

using MovieTickets.Services.Data.Interfaces;

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
	}
}
