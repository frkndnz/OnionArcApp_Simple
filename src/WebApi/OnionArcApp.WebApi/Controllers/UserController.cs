﻿using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnionArcApp.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser()
        {
            throw new NotImplementedException();
        }
    }
}
