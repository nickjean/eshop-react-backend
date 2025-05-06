using AutoMapper;
using EShop_React.Commands;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using EShop_React.Repositories.Interface;
using MediatR;

namespace EShop_React.Command.Handler
{
    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, ResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ResponseDto _responseDto = new ResponseDto();
        public AddProductCommandHandler(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }

        public async Task<ResponseDto> Handle(AddProductCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var product = _mapper.Map<Product>(command);
                await _productRepository.CreateProduct(product);
            }
            catch (Exception)
            {
                _responseDto.Message = "An error has occured.";
                _responseDto.IsSuccess = false;
            }

            _responseDto.Message = "Add Product Successfully.";
            _responseDto.IsSuccess = true;
            return _responseDto;
        }
    }
}
