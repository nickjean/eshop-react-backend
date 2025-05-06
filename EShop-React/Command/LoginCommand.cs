using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class LoginCommand : IRequest<ResponseDto>
    {
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
