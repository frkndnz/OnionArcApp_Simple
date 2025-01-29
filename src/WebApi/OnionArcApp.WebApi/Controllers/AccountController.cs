using System.Linq.Expressions;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Features.AccountOperations.Commands.CreateAccount;

namespace OnionArcApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> AddAccount(CreateAccountDto createDto)
        {
            var command= new CreateAccountCommand();


            var userId = User.FindFirst(ClaimTypes.NameIdentifier);
            if (userId == null)
                return BadRequest(new {Message="user not found!"});

            var userGuidId = Guid.Parse(userId!.Value);

            command.UserId = userGuidId;
            command.CreateAccountDto = createDto;

            var result =await  _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);
            

            return Ok(result);
        }
    }
}
