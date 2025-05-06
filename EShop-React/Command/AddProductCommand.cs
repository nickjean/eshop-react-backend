using EShop_React.Enum;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class AddProductCommand : IRequest<ResponseDto>
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public List<Gender> Gender { get; set; } = new List<Gender>();
        public string? Color { get; set; }
        public Category Category { get; set; }
    }
}
