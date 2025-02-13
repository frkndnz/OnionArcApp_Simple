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
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        private readonly DbSet<Transaction> _transactionSet;
        public TransactionRepository(AppDbContext dbContext) : base(dbContext)
        {
            _transactionSet= dbContext.Set<Transaction>();
        }

        
    }
}
