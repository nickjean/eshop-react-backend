using EShop_React.Command;
using EShop_React.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShop_React.Controllers
{
    [Route("api/order")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetAllOrderOfUser(string userId) 
        {
            var command = new GetAllOrderWithUserIdCommand
            {
                Id = userId
            };

            var responseDto = await _mediator.Send(command);

            if (responseDto.Result == null && responseDto.IsSuccess == true)
            {
                return NotFound(responseDto);
            }
            else if (responseDto.IsSuccess == false) 
            {
                return BadRequest(responseDto);
            }

            return Ok(responseDto);
        }
    }
}
