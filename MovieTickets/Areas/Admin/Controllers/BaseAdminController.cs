using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using static MovieTickets.Web.Areas.Admin.AdminConstants;

namespace MovieTickets.Web.Areas.Admin.Controllers
{ 
	[Area(AreaName)]

	[Authorize(Roles = AdminRoleName)]
	public class BaseAdminController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
