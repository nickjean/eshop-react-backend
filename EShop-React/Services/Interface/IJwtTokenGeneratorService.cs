using EShop_React.Models;

namespace EShop_React.Services.Interface
{
    public interface IJwtTokenGeneratorService
    {
        string GenerateToken(ApplicationUser applicationUser, IEnumerable<string> roles);
    }
}
