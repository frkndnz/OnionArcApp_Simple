﻿using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Features.UserOperations.Commands.CreateUser;
using OnionArcApp.Application.Features.UserOperations.Commands.LoginUser;

namespace OnionArcApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody]CreateUserCommand createUserCommand)
        {
            var result=await _mediator.Send(createUserCommand);
            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser([FromBody]LoginUserCommand loginUserCommand)
        {
            var result=await _mediator.Send(loginUserCommand);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [Authorize(Roles ="Admin,User")]
        [HttpGet("info")]
        public IActionResult GetUserInfo()
        { 
            
           return Ok( new
           {
               Username=User.FindFirst(ClaimTypes.Name).Value,
               Role=User.FindFirst(ClaimTypes.Role).Value
           } );
        }
    }
}
