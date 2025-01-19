using MediatR;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Features.UserOperations.Commands.CreateUser;
using OnionArcApp.Application.Features.UserOperations.Commands.LoginUser;

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
    }
}
