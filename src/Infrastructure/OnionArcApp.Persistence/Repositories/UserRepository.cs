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
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly AppDbContext dbContext;

        public UserRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await dbContext.Set<User>().FirstOrDefaultAsync(u=>u.Email==email);
        }

        public async Task<User?> FindByNameAsync(string name)
        {
            return await dbContext.Set<User>().FirstOrDefaultAsync(u => u.Name == name);
        }
    }
}
