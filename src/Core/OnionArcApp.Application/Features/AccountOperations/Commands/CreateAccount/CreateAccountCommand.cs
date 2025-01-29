using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Enums;

namespace OnionArcApp.Application.Features.AccountOperations.Commands.CreateAccount
{
    public class CreateAccountCommand:IRequest<ServiceResponse<Guid>>
    {
        public Guid UserId { get; set; }
        public CreateAccountDto CreateAccountDto { get; set; }

    }
}
