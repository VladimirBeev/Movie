using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using MovieTickets.Data.EntityModels;
using MovieTickets.Services.Data.Interfaces;
using MovieTickets.Web.Infrastructure.Extensions;
using MovieTickets.Web.ViewModels.Actor;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    [Authorize]
    public class ActorController : Controller
    {
        private readonly IActorService actorService;
        private readonly UserManager<ApplicationUser> userManager;

        public ActorController(IActorService actorService, UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
            this.actorService = actorService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> AllActors()
        {
            var allActors = await actorService.GetAllActorsAsync();

            if (allActors == null)
            {
                return View("NotFound");
            }

            return View(allActors);
        }

        [HttpGet]
        public IActionResult Create()
        {
            if (User.Role() == "Admin")
            {
                return View();
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Create(ActorViewModel actorModel)
        {
            if (!ModelState.IsValid)
            {
                return View(actorModel);
            }

            try
            {
                await actorService.AddActorAsync(actorModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Add an Actor. Please try again.");

                return View(actorModel);
            }

            TempData[SuccessMessage] = "You Create an Actor";

            return RedirectToAction("AllActors");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await actorService.GetActorByIdAsync(id);

            if (actorDetails == null)
            {
                return View("NotFound");
            }
            return View(actorDetails);
        }

        [HttpGet]

        public async Task<IActionResult> Edit(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    var actorEdit = await actorService.GetActorByIdAsync(id);
                    if (actorEdit == null)
                    {
                        return View("NotFound");
                    }

                    return View(actorEdit);
                }
                catch (Exception)
                {

                    return View(nameof(NotFound));
                }
            }

            return RedirectToAction("AccessDenied", "Account");
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ActorViewModel actorModel)
        {
            if (!ModelState.IsValid)
            {
                return View(actorModel.Id);
            }

            try
            {
                await actorService.UpdateActorAsync(actorModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Error occur while Edit an Actor. Please try again.");

                return View(actorModel.Id);
            }

            TempData[SuccessMessage] = "Successfully Edit an Actor";

            return RedirectToAction("AllActors");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.Role() == "Admin")
            {
                try
                {
                    await actorService.DeleteActorAsync(id);
                }
                catch (Exception)
                {
                    TempData[ErrorMessage] = "Error on Delete Actor, Please try again";

                    return RedirectToAction("AllActors");
                }


                TempData[SuccessMessage] = "You Delete Complete";

                return RedirectToAction("AllActors");
            }

            return RedirectToAction("AccessDenied", "Account");
        }
    }
}
