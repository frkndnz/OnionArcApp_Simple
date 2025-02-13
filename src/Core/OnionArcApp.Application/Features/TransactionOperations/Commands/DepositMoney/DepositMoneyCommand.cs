using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.TransactionOperations.Commands.DepositMoney
{
    public class DepositMoneyCommand:IRequest<ServiceResponse<Guid>>
    {
        public string AccountNumber { get; set; } = default!;
        public decimal Amount { get; set; } = default!;
        public string? Description { get; set; }
    }
}
