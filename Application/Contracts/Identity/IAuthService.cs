using Application.Models.Identity;
using Domain.Models.Authentication;

namespace Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<Authentication> Login(AuthRequest request);
        Task<RegistrationResponse> Register(RegistrationRequest request);
    }
}
