using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace OnionArcApp.Application.Features.TransactionOperations.Commands.WithDrawMoney
{
    public class WithdrawMoneyValidator:AbstractValidator<WithdrawMoneyCommand>
    {
        public WithdrawMoneyValidator() 
        {
            RuleFor(x => x.Amount).GreaterThan(0);

        }
    }
}
