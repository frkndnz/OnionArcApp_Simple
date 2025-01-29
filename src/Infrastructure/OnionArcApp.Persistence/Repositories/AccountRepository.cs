using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Domain.Entities;
using OnionArcApp.Persistence.Context;

namespace OnionArcApp.Persistence.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(AppDbContext dbContext) : base(dbContext)
        {

        }
    }
}
