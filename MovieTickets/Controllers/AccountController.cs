using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Account;

namespace MovieTickets.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly MovieDbContext movieDbContext;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, MovieDbContext movieDbContext)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.movieDbContext = movieDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            var users = await movieDbContext.Users.ToListAsync();

            return View(users);
        }

        [HttpGet]
        public IActionResult Login()
        {
            var newLogin = new LoginViewModel();

            return View(newLogin);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = await userManager.FindByEmailAsync(loginViewModel.EmailAddress);

            if (user != null)
            {
                var passworCheck = await userManager
                    .CheckPasswordAsync(user, loginViewModel.Password);

                if (passworCheck)
                {
                    var result = await signInManager
                        .PasswordSignInAsync(user, loginViewModel.Password, false, false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("AllMovies", "Movie");
                    }
                }

                TempData["Error"] = "Wrong credentials. Please, try again!";

                return View(loginViewModel);
            }

            TempData["Error"] = "Wrong credentials. Please, try again!";

            return View(loginViewModel);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var registerViewModel = new RegisterViewModel();

            return View(registerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }

            var user = await userManager.FindByEmailAsync(registerViewModel.Email);

            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";

                return View(registerViewModel);
            }

            var newUser = new ApplicationUser()
            {
                FullName = registerViewModel.FullName,
                Email = registerViewModel.Email,
                UserName = registerViewModel.Email
            };

            var newUserResponse = await userManager.CreateAsync(newUser, registerViewModel.Password);

            if (newUserResponse.Succeeded)
            {
                await userManager.AddToRoleAsync(newUser, "User");
            }

            return View("RegisterCompleted");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();

            return RedirectToAction("Index", "Movies");
        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            return View();
        }
    }
}
