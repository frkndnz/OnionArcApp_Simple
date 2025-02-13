using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.TransactionOperations.Commands.WithDrawMoney
{
    public class WithdrawMoneyCommand:IRequest<ServiceResponse<Guid>>
    {
        public string AccountNumber { get; set; } = default!;
        public decimal Amount { get; set; }
    }
}
