using AutoMapper;
using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using EShop_React.Models.Response;
using EShop_React.Repositories.Interface;
using EShop_React.Services;
using EShop_React.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop_React.Command.Handler
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ResponseDto>
    {
        private readonly IAuthRepository _authRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private IJwtTokenGeneratorService _jwtTokenGeneratorService;
        private ResponseDto _responseDto = new ResponseDto();

        public LoginCommandHandler(IMapper mapper, IAuthRepository authRepository, UserManager<ApplicationUser> userManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _authRepository = authRepository;
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<ResponseDto> Handle(LoginCommand command, CancellationToken cancellationToken)
        {
            var user = _authRepository.GetUserByEmail(command.Email);
            bool isValid = await _userManager.CheckPasswordAsync(user, command.Password);

            if (!isValid || user == null)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Result = new LoginResponse { User = null, Token = "" };
                _responseDto.Message = "Username or password is incorrect.";
                return _responseDto;
            }
            var roles = await _userManager.GetRolesAsync(user);

            var token = _jwtTokenGeneratorService.GenerateToken(user, roles);

            UserDto userDto = new UserDto
            {
                Email = user.Email,
                Id = user.Id,
                Name = user.Name
            };

            LoginResponse loginResponseDto = new LoginResponse
            {
                User = userDto,
                Token = token
            };

            _responseDto.Result = loginResponseDto;
            _responseDto.IsSuccess = true;

            return _responseDto;
        }
    }
}
