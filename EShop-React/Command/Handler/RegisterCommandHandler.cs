using AutoMapper;
using EShop_React.Commands;
using EShop_React.Data;
using EShop_React.Models;
using EShop_React.Models.Dtos;
using EShop_React.Repositories.Interface;
using EShop_React.Services.Interface;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop_React.Command.Handler
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ResponseDto>
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepository _authRepository;
        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private IJwtTokenGeneratorService _jwtTokenGeneratorService;
        private ResponseDto _responseDto = new ResponseDto();

        public RegisterCommandHandler(IMapper mapper, IAuthRepository authRepository, AppDbContext appDbContext, UserManager<ApplicationUser> userManager, IJwtTokenGeneratorService jwtTokenGeneratorService)
        {
            _mapper = mapper;
            _authRepository = authRepository;
            _appDbContext = appDbContext;
            _userManager = userManager;
            _jwtTokenGeneratorService = jwtTokenGeneratorService;
        }

        public async Task<ResponseDto> Handle(RegisterCommand command, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(command);

            try
            {
                var result = await _authRepository.CreateUserAync(user, command.Password);

                if (result.Succeeded)
                {
                    var isSucceed = await _authRepository.CreateRoleAsync(command);

                    if (isSucceed)
                    {
                        _responseDto.IsSuccess = true;
                        _responseDto.Message = "Registration Successfull.";
                        return _responseDto;
                    }

                    _responseDto.IsSuccess = false;
                    _responseDto.Message = "Error Encountered.";
                    return _responseDto;
                }
                else
                {
                    _responseDto.IsSuccess = false;
                    _responseDto.Message = result.Errors.FirstOrDefault().Description;
                    return _responseDto;
                }


            }
            catch (Exception)
            {
                _responseDto.IsSuccess = false;
                _responseDto.Message = "Error Encountered.";
                return _responseDto;
            }
        }
    }
}
