using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<ServiceResponse<Guid>>
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
