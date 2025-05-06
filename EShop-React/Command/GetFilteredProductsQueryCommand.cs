using EShop_React.Models;
using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class GetFilteredProductsQueryCommand : IRequest<ResponseDto>
    {
        public List<string>? Genders { get; set; }
        public string? Color { get; set; }
        public string? Category { get; set; }
    }
}
