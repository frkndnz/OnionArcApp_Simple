using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.TransactionOperations.Commands.WithDrawMoney
{
    public class WithdrawMoneyCommandHandler : IRequestHandler<WithdrawMoneyCommand, ServiceResponse<Guid>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IValidator<WithdrawMoneyCommand> _validator;
        public WithdrawMoneyCommandHandler(IAccountRepository accountRepository, ITransactionRepository transactionRepository, IValidator<WithdrawMoneyCommand> validator)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
            _validator = validator;
        }

        public async Task<ServiceResponse<Guid>> Handle(WithdrawMoneyCommand request, CancellationToken cancellationToken)
        {
            var account= await _accountRepository.GetByAccountNumber(request.AccountNumber);
            if (account == null)
                return ServiceResponse<Guid>.FailureResponse("account not found!");

            var validationResult = _validator.Validate(request);
            if (!validationResult.IsValid)
                return ServiceResponse<Guid>.ValidationFailedResponse(validationResult.Errors);

            if (account.Balance < request.Amount)
                return ServiceResponse<Guid>.FailureResponse("yetersiz bakiye!");


            var transaction=new Transaction
            {
                Account=account,
                TransactionDate=DateTime.UtcNow,
                TransactionType=Domain.Enums.TransactionType.Withdrawal,
                Description="withdraw",
                Amount=request.Amount,
            };

            var addedTrans= await _transactionRepository.AddAsync(transaction);

            account.Balance-=request.Amount;

            await _accountRepository.UpdateAsync(account);

            return ServiceResponse<Guid>.SuccessResponse(addedTrans.Id);
        }
    }

    
}
