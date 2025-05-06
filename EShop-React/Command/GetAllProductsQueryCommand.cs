using EShop_React.Models;
using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class GetAllProductsQueryCommand : IRequest<ResponseDto>
    {
    }
}
