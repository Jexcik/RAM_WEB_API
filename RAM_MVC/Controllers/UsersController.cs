using Microsoft.AspNetCore.Mvc;

namespace RAM_MVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly IAuthenticationService _authenticationService;
        public UsersController(IAuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }
        public IActionResult Login(string returnUrl=null)
        {
            return View();
        }
    }
}
