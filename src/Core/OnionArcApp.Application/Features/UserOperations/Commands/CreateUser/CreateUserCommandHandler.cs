using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Interfaces.Token;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.UserOperations.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ServiceResponse<Guid>>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public CreateUserCommandHandler(ITokenHandler tokenHandler, IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<Guid>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var existUser = await _userRepository.FindByEmailAsync(request.Email);
            if (existUser != null)
                return ServiceResponse<Guid>.FailureResponse("email already exists!");

            //validate edilecek



            var user = await _userRepository.AddAsync(_mapper.Map<User>(request));

            return ServiceResponse<Guid>.SuccessResponse(user.Id);
        }
    }
}
