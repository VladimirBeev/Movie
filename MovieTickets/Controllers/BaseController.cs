using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MovieTickets.Web.Controllers
{
	[Authorize]
	[AutoValidateAntiforgeryToken]
	public class BaseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
