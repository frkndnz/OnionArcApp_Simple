using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Domain.Entities;
using OnionArcApp.Persistence.Context;

namespace OnionArcApp.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        private readonly DbSet<Account> _dbSet;
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {
            _dbSet=dbContext.Set<Account>();
        }

        public async Task<Account> GetUserAccountByUserId(Guid userId)
        {
            var account=await _dbSet.FirstOrDefaultAsync(a=>a.User.Id==userId);
            return account;
        }

        public async Task<List<Account>> GetUserAccountsByUserId(Guid userId)
        {
            var accounts= await _dbSet.Where(a=>a.User.Id==userId).ToListAsync();
            return accounts;
        }
    }
}
