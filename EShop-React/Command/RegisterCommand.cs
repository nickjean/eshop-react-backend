using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Commands
{
    public class RegisterCommand : IRequest<ResponseDto>
    {
        public string? Email { get; init; }
        public string? Name { get; init; }
        public string? Password { get; init; }
        public string Role { get; init; } = "Customer";
    }
}
