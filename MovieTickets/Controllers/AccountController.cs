using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using MovieTickets.Data;
using MovieTickets.Data.EntityModels;
using MovieTickets.Web.ViewModels.Account;

using static MovieTickets.Common.NotificationsConstant;

namespace MovieTickets.Web.Controllers
{
    public class AccountController : BaseController
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
            try
            {
                var users = await movieDbContext.Users.ToListAsync();

                return View(users);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Get Users action make an Error";

                return RedirectToAction("Index","Home");
            }
           
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

            try
            {
                var user = await userManager.Users.FirstOrDefaultAsync(e => e.Email == loginViewModel.EmailAddress);

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
                            TempData[InformationsMessage] = "You are Signin";

                            return RedirectToAction("AllMovies", "Movie");
                        }
                    }

                    TempData[ErrorMessage] = "Wrong credentials. Please, try again!";

                    return View(loginViewModel);
                }

                TempData[ErrorMessage] = "Wrong credentials. Please, try again!";

                return View(loginViewModel);
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Login, Please try again";

                return View(nameof(loginViewModel));
            }
            
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
                TempData[ErrorMessage] = "Register Error";

                return View(registerViewModel);
            }
            try
            {
                var user = await userManager.FindByEmailAsync(registerViewModel.Email);

                if (user != null)
                {
                    TempData[ErrorMessage] = "This email address is already in use";

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

                TempData[SuccessMessage] = "Register Completed";

                return View("RegisterCompleted");
            }
            catch (Exception)
            {
                TempData[ErrorMessage] = "Error on Register, Please try again";

                return View(nameof(Register));
            }
            
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            try
            {
                await signInManager.SignOutAsync();
            }
            catch (Exception)
            {

                TempData[ErrorMessage] = "Error in Logout";

                return RedirectToAction("Index", "Home");
            }

            TempData[InformationsMessage] = "You are logout";

            return RedirectToAction("AllMovies", "Movie");

        }

        public IActionResult AccessDenied(string ReturnUrl)
        {
            TempData[WarningMessage] = "Access Denied";
            return View();
        }
    }
}
