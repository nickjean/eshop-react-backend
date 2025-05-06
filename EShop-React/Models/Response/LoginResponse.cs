using EShop_React.Models.Dtos;

namespace EShop_React.Models.Response
{
    public class LoginResponse
    {
        public UserDto User { get; set; }
        public string Token { get; set; }
    }
}
