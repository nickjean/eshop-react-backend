using Azure.Core;
using EShop_React.Data;
using EShop_React.Enum;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using EShop_React.Repositories.Interface;
using MediatR;

namespace EShop_React.Command.Handler
{
    public class GetFilteredProductsQueryHandler : IRequestHandler<GetFilteredProductsQueryCommand, ResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly IProductRepository _productRepository;
        private ResponseDto _responseDto = new ResponseDto();

        public GetFilteredProductsQueryHandler(AppDbContext context, IProductRepository productRepository)
        {
            _context = context;
            _productRepository = productRepository;
        }

        public async Task<ResponseDto> Handle(GetFilteredProductsQueryCommand command, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts(cancellationToken);

            try 
            {
                // Filter by Gender (Flags)
                if (command.Genders != null && command.Genders.Any())
                {
                    var parsedGenders = command.Genders?
                    .Select(g => System.Enum.TryParse<Gender>(g, true, out var parsed) ? parsed : (Gender?)null)
                    .Where(g => g.HasValue)
                    .Select(g => g.Value)
                    .ToList();

                    products = products
                                .Where(p => p.Gender.Any(g => parsedGenders.Contains(g)))
                                .ToList();
                }

                // Filter by Color
                if (!string.IsNullOrWhiteSpace(command.Color))
                {
                    products = products.Where(p => p.Color?.ToLower() == command.Color.ToLower()).ToList();
                }

                // Filter by Category
                if (!string.IsNullOrWhiteSpace(command.Category) &&
                    System.Enum.TryParse<Category>(command.Category, true, out var parsedCategory))
                {
                    products = products.Where(p => p.Category == parsedCategory).ToList();
                }

                _responseDto.Result = products;
                _responseDto.IsSuccess = true;

                return _responseDto;
            } catch (Exception) 
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Failed to query the products.";
                return _responseDto;
            }
        }
    }
}
