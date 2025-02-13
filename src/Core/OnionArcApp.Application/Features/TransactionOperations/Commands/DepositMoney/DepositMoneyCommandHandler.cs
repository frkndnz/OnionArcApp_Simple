using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Features.TransactionOperations.Commands.DepositMoney
{
    public class DepositMoneyCommandHandler : IRequestHandler<DepositMoneyCommand, ServiceResponse<Guid>>
    {
        ITransactionRepository _transactionRepository;
        IAccountRepository _accountRepository;

        public DepositMoneyCommandHandler(ITransactionRepository transactionRepository, IUserRepository userRepository, IAccountRepository accountRepository)
        {
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }
        public async Task<ServiceResponse<Guid>> Handle(DepositMoneyCommand request, CancellationToken cancellationToken)
        {
            var account= await _accountRepository.GetByAccountNumber(request.AccountNumber);
            if (account == null)
                return ServiceResponse<Guid>.FailureResponse("not found account!");

            account.Balance += request.Amount;
            await _accountRepository.UpdateAsync(account);

            var transaction = new Transaction
            {
                Account = account,
                Amount = request.Amount,
                Description = request.Description,
                TransactionType = Domain.Enums.TransactionType.Deposit,
                TransactionDate = DateTime.Now,
            };

           var addedTrans= await _transactionRepository.AddAsync(transaction);

            return ServiceResponse<Guid>.SuccessResponse(addedTrans.Id);
        }
    }
}
