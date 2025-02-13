using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using OnionArcApp.Application.Dto.Transaction;
using OnionArcApp.Application.Wrappers;

namespace OnionArcApp.Application.Features.TransactionOperations.Queries.GetAccountTransactions
{
    public class GetAccountTransactionsQuery:IRequest<ServiceResponse<List<TransactionDto>>>
    {
        public string AccountNumber { get; set; }
    }
}
