using Microsoft.AspNetCore.Mvc;

namespace MovieTickets.Web.Areas.Admin.Controllers
{
	public class HomeController : BaseAdminController
	{
		public IActionResult Admin()
		{
			return View();
		}
	}
}
