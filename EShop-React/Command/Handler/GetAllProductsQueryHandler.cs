using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using EShop_React.Repositories.Interface;
using EShop_React.Services.Interface;
using MediatR;

namespace EShop_React.Command.Handler
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQueryCommand, ResponseDto>
    {
        private readonly IProductRepository _productRepository;
        private ResponseDto _responseDto = new ResponseDto();

        public GetAllProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<ResponseDto> Handle(GetAllProductsQueryCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var products = await _productRepository.GetAllProducts(cancellationToken);
                _responseDto.IsSuccess = true;
                _responseDto.Result = products;
                return _responseDto;

            }
            catch (Exception)
            {
                _responseDto.Message = "An error has occured.";
                _responseDto.IsSuccess = false;
                return _responseDto;
            }
        }
    }

}
