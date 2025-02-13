using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Dto.Transaction;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.TransactionOperations.Queries.GetAccountTransactions
{
    public class GetAccountTransactionQueryHandler : IRequestHandler<GetAccountTransactionsQuery, ServiceResponse<List<TransactionDto>>>
    {
        private readonly IMapper _mapper;
        private readonly ITransactionRepository _transactionRepository;
        private readonly IAccountRepository _accountRepository;

        public GetAccountTransactionQueryHandler(IMapper mapper, ITransactionRepository transactionRepository, IAccountRepository accountRepository)
        {
            _mapper = mapper;
            _transactionRepository = transactionRepository;
            _accountRepository = accountRepository;
        }


        public async Task<ServiceResponse<List<TransactionDto>>> Handle(GetAccountTransactionsQuery request, CancellationToken cancellationToken)
        {
            var account=await _accountRepository.GetByAccountNumber(request.AccountNumber);

            if (account == null)
                return ServiceResponse<List<TransactionDto>>.FailureResponse("not found account!");

            var transactions = await _transactionRepository.GetAllAsync();
            transactions=transactions.Where(t=>t.Account.Id==account.Id).ToList();

            var Dtos=_mapper.Map<List<TransactionDto>>(transactions);

            return ServiceResponse<List<TransactionDto>>.SuccessResponse(Dtos);
        }
    }
}
