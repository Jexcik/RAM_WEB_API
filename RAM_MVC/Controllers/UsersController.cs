using Microsoft.AspNetCore.Mvc;
using RAM_MVC.Models;

namespace RAM_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login(string returnUrl = null)
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM login, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var isLoggedIn = await _authenticationService.Authenticate(login.Email, login.Password);
                if (isLoggedIn)
                {
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "Попытка входа в систему не удалась. Попробуйте еще раз");
            return View(login);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registration)
        {
            if (!ModelState.IsValid)
            {
                var returnUrl = Url.Content("~/");
                var isCreated = await _authenticationService.Register(registration);
                if (isCreated)
                {
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError("", "Попытка регистрации не удалась. Пожалуйста, попробуйте еще раз.");
            return View(registration);
        }

        [HttpPost]
        public async Task<IActionResult> Logout(string returnUrl)
        {
            returnUrl ??= Url.Content("~/");
            await _authenticationService.Logout();
            return LocalRedirect(returnUrl);
        }
    }
}
