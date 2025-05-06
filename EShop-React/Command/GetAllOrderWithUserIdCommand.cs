using EShop_React.Models.Dtos;
using MediatR;

namespace EShop_React.Command
{
    public class GetAllOrderWithUserIdCommand : IRequest<ResponseDto>
    {
        public string Id { get; set; }
    }
}
