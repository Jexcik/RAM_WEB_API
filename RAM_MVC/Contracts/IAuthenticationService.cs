using RAM_MVC.Models;

public interface IAuthenticationService
{
    Task<bool> Authenticate(string email, string password);
    Task<bool> Register(RegisterVM registration);
    Task Logout();
}