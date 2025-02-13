using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Application.Dto.Account;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Interfaces.Repository
{
    public interface IAccountRepository:IGenericRepositoryAsync<Account>
    {
        Task<List<Account>> GetUserAccountsByUserId(Guid userId);
        Task<Account> GetUserAccountByUserId(Guid userId);

        Task<Account> GetByAccountNumber(string accountNumber);
    }
}
