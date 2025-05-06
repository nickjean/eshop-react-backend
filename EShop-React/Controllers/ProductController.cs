using AutoMapper;
using EShop_React.Command;
using EShop_React.Command.Handler;
using EShop_React.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop_React.Controllers
{
    [Route("api/product")]
    [ApiController]    
    public class ProductController : Controller
    {
        private readonly IMediator _mediator;
        protected ResponseDto _responseDto = new ResponseDto();

        public ProductController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct([FromBody] AddProductCommand productCommand) 
        {
            var response = await _mediator.Send(productCommand);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("get-all-product")]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await _mediator.Send(new GetAllProductsQueryCommand());

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpGet("filter")]
        public async Task<IActionResult> FilterProducts(
        [FromQuery] List<string>? genders,
        [FromQuery] string? color,
        [FromQuery] string? category)
        {
            var responseDto = await _mediator.Send(new GetFilteredProductsQueryCommand
            {
                Genders = genders,
                Color = color,
                Category = category
            });

            if (!responseDto.IsSuccess) 
            { 
                return BadRequest(responseDto);
            }

            return Ok(responseDto);
        }
    }
}
