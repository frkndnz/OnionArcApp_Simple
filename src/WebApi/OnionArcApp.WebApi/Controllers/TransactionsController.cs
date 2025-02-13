using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnionArcApp.Application.Features.TransactionOperations.Commands.DepositMoney;
using OnionArcApp.Application.Features.TransactionOperations.Commands.WithDrawMoney;
using OnionArcApp.Application.Features.TransactionOperations.Queries.GetAccountTransactions;

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

        [HttpGet("account")]
        public async Task<IActionResult> GetAccountTransactions([FromQuery] GetAccountTransactionsQuery query)
        {
            var result = await _mediator.Send(query);

            if(!result.Success)
                return NotFound(result);

            return Ok(result);
        }


        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit([FromBody] DepositMoneyCommand command)
        {
            var result=await _mediator.Send(command);

            if(!result.Success)
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> WithDraw([FromBody] WithdrawMoneyCommand command)
        {
            var result= await _mediator.Send(command);

            if (!result.Success)
                return BadRequest(result);

            return Ok(result);  
        }
    }
}
