using AutoMapper;
using Azure.Core;
using EShop_React.Command;
using EShop_React.Commands;
using EShop_React.Models.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop_React.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand registerCommand)
        {
            var response = await _mediator.Send(registerCommand);

            if (!response.IsSuccess)
            {
                return BadRequest(response);
            }

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand loginCommand)
        {
            var response = await _mediator.Send(loginCommand);

            if (response.Result == null)
            {
                response.IsSuccess = false;
                response.Message = "Username or password is incorrect";
                return BadRequest(response);
            }

            return Ok(response);
        }
    }
}
