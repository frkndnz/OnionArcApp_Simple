﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Dto.Token;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.UserOperations.Commands.LoginUser
{
    public class LoginUserCommand:IRequest<ServiceResponse<TokenDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
