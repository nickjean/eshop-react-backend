using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class LoginCommand : IRequest<ResponseDto>
    {
        public string? Email { get; init; }
        public string? Password { get; init; }
    }
}
