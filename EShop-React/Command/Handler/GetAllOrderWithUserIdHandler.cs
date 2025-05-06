using EShop_React.Models.Dtos;
using EShop_React.Repositories.Interface;
using EShop_React.Services.Interface;
using MediatR;

namespace EShop_React.Command.Handler
{
    public class GetAllOrderWithUserIdHandler : IRequestHandler<GetAllOrderWithUserIdCommand, ResponseDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ResponseDto _responseDto = new ResponseDto();

        public GetAllOrderWithUserIdHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<ResponseDto> Handle(GetAllOrderWithUserIdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var orders = await _orderRepository.GetAllOrdersForUser(command.Id);

                if (orders.Count() == 0) 
                {
                    _responseDto.Result = null;
                    _responseDto.IsSuccess = true;
                    _responseDto.Message = "No order for this user.";
                    return _responseDto;
                }
                 
                _responseDto.Result = orders;
                _responseDto.IsSuccess = true;
                return _responseDto;
            }
            catch (Exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "An error has occured.";
                return _responseDto;
            }
        }    
    }
}
