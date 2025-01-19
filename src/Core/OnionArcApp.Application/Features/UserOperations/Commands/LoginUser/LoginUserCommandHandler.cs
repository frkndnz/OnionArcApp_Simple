using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Dto.Token;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Interfaces.Token;
using OnionArcApp.Application.Interfaces.UserPassword;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.UserOperations.Commands.LoginUser
{

    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, ServiceResponse<TokenDto>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordService _passwordService;
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;

        public LoginUserCommandHandler(IUserRepository userRepository, ITokenHandler tokenHandler, IMapper mapper, IPasswordService passwordService)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
            _mapper = mapper;
            _passwordService = passwordService;
        }

        public async Task<ServiceResponse<TokenDto>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            // kullanıcı varmı kontrolü yapılacak
            var user=await _userRepository.FindByEmailAsync(request.Email);
            if (user == null)
                return ServiceResponse<TokenDto>.FailureResponse("User not found");

            // şifre dogrulama
            if(!_passwordService.VerifyPassword(user.PasswordHash, request.Password))
                return ServiceResponse<TokenDto>.FailureResponse("Password does not match!");

            var token = _tokenHandler.CreateAccessToken();

            return ServiceResponse<TokenDto>.SuccessResponse(token);
        }
    }
}
