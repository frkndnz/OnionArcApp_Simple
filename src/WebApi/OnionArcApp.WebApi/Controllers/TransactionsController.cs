using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Features.TransactionOperations.Commands.DepositMoney;

namespace OnionArcApp.WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionsController:ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositMoneyCommand command)
        {
            var result=await _mediator.Send(command);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
