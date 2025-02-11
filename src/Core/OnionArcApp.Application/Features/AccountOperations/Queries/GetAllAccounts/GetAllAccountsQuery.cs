using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.AccountOperations.Queries.GetAllAccounts
{
    public class GetAllAccountsQuery: IRequest<ServiceResponse<List<AccountDto>>>
    {

    }
}
