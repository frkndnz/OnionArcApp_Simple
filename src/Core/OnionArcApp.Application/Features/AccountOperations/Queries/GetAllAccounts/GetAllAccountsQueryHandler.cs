using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.AccountOperations.Queries.GetAllAccounts
{
    public class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, ServiceResponse<List<AccountDto>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;
        public GetAllAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }
        public async Task<ServiceResponse<List<AccountDto>>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _accountRepository.GetAllIncludesAsync(a=>a.User,a=>a.Transactions);
            if (accounts == null)
                return ServiceResponse<List<AccountDto>>.FailureResponse("accounts not found!");

            var accountsDto=_mapper.Map<List<AccountDto>>(accounts);

            return ServiceResponse<List<AccountDto>>.SuccessResponse(accountsDto);
        }
    }
}
