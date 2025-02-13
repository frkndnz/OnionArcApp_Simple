using System.Linq.Expressions;
using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Features.AccountOperations.Commands.CreateAccount;
using OnionArcApp.Application.Features.AccountOperations.Queries.GetAllAccounts;
using OnionArcApp.Application.Features.AccountOperations.Queries.GetUserAccounts;

namespace OnionArcApp.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllAccounts()
        {
            var query = new GetAllAccountsQuery();
            var result=await _mediator.Send(query);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("me")]
        [Authorize(Roles ="User")]
        public async Task<IActionResult> GetUserAccounts()
        {
            var UserId=User.FindFirst(ClaimTypes.NameIdentifier);
            if(UserId== null)
                return Unauthorized();

            var userGuidId=Guid.Parse(UserId.Value);

            var query=new GetUserAccountsQuery();
            query.UserId = userGuidId;

            var result=await _mediator.Send(query);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserAccountById(Guid id)
        {
            throw new NotImplementedException();
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
