using EShop_React.Commands;
using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Repositories.Interface;
using Microsoft.AspNetCore.Identity;

namespace EShop_React.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AppDbContext _appDbContext;
        public AuthRepository(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _appDbContext = appDbContext;
        }

        public async Task<bool> CreateRoleAsync(RegisterCommand registerCommand)
        {
            var user = GetUserByEmail(registerCommand.Email);
            if (user != null)
            {
                if (!_roleManager.RoleExistsAsync(registerCommand.Role).GetAwaiter().GetResult())
                {
                    registerCommand.Role = char.ToUpper(registerCommand.Role[0]) + registerCommand.Role.Substring(1).ToLower(); ;
                    _roleManager.CreateAsync(new IdentityRole(registerCommand.Role)).GetAwaiter().GetResult();
                }

                await _userManager.AddToRoleAsync(user, registerCommand.Role);

                return true;
            }

            return false;
        }

        public async Task<IdentityResult> CreateUserAync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public ApplicationUser GetUserByEmail(string email) 
        {
            return _appDbContext.ApplicationUsers.FirstOrDefault(u => u.UserName.ToLower() == email.ToLower());
        }
    }
}
