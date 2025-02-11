using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.AccountOperations.Queries.GetUserAccounts
{
    public class GetUserAccountsQuery:IRequest<ServiceResponse<List<AccountDto>>>
    {
        public Guid UserId { get; set; }
    }
}
