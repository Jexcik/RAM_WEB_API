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
            if (ModelState.IsValid)
            {
                returnUrl ??= Url.Content("~/");
                var isLoggedIn = await _authenticationService.Authenticate(login.Email, login.Password);
                if (isLoggedIn) 
                {
                    return LocalRedirect(returnUrl);
                }
            }
            ModelState.AddModelError("","Попытка входа в систему не удалась. Попробуйте еще раз");
            return View(login);
        }
    }
}
