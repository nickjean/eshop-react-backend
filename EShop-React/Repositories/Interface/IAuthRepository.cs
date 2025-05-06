using EShop_React.Commands;
using EShop_React.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace EShop_React.Repositories.Interface
{
    public interface IAuthRepository
    {
        Task<IdentityResult> CreateUserAync(ApplicationUser user, string password);
        Task<bool> CreateRoleAsync(RegisterCommand registerCommand);
        ApplicationUser GetUserByEmail(string email);
    }
}
