using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Interfaces.Token;
using OnionArcApp.Application.Interfaces.UserPassword;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordService _passwordService;
        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, IPasswordService passwordService, IRoleRepository roleRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordService = passwordService;
            _roleRepository = roleRepository;
        }
        public async Task<ServiceResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.FindByEmailAsync(request.Email);
            if (existUser != null)
                return ServiceResponse<Guid>.FailureResponse("email already exists!");


            var hashPassword=_passwordService.HashPassword(request.Password);
            

            var defaultRole = await _roleRepository.GetByName("User");
            if (defaultRole == null)
                throw new Exception("defaultRole is not found");

            var user=_mapper.Map<User>(request);
            user.PasswordHash = hashPassword;
            user.Role = defaultRole;
            var addedUser = await _userRepository.AddAsync(user);

            return ServiceResponse<Guid>.SuccessResponse(addedUser.Id);
        }
    }
}
