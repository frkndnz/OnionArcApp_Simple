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

namespace OnionArcApp.Application.Features.AccountOperations.Queries.GetUserAccounts
{
    public class GetUserAccountsQueryHandler : IRequestHandler<GetUserAccountsQuery, ServiceResponse<List<AccountDto>>>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IMapper _mapper;

        public GetUserAccountsQueryHandler(IAccountRepository accountRepository, IMapper mapper)
        {
            _accountRepository = accountRepository;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<AccountDto>>> Handle(GetUserAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts=await _accountRepository.GetUserAccountsByUserId(request.UserId);
            if (accounts == null || accounts.Count == 0)
                return ServiceResponse<List<AccountDto>>.FailureResponse("not accounts!");

            return ServiceResponse<List<AccountDto>>.SuccessResponse(_mapper.Map<List<AccountDto>>(accounts));
        }
    }
}
