using CaseAlp.Models;

namespace CaseAlp.Services
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(RegisterViewModel model);
        Task<bool> AuthenticateUserAsync(LoginViewModel model);
        // Add any other user-related methods you need
    }

}
