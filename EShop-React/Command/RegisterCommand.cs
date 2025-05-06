using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Commands
{
    public class RegisterCommand : IRequest<ResponseDto>
    {
        public string? Email { get; set; }
        public string? Name { get; set; }
        public string? Password { get; set; }
        public string Role { get; set; } = "Customer";
    }
}
