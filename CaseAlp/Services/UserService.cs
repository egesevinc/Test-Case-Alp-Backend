using CaseAlp.Data;
using CaseAlp.Models;
using System.Threading.Tasks;

namespace CaseAlp.Services
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _dbContext; 

        public UserService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> RegisterUserAsync(RegisterViewModel model)
        {
           
            var isEmailUnique = await IsEmailUniqueAsync(model.Email);

            if (!isEmailUnique)
            {
                return false; 
            }

            var user = new User
            {
                Email = model.Email,
                
            };

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> AuthenticateUserAsync(LoginViewModel model)
        {
           
            var isValidCredentials = await IsValidCredentialsAsync(model.Email, model.Password);

            return isValidCredentials;
        }

        private async Task<bool> IsEmailUniqueAsync(string email)
        {
           
            return true;
        }

        private async Task<bool> IsValidCredentialsAsync(string email, string password)
        {
    
            return true;
        }
    }
}
