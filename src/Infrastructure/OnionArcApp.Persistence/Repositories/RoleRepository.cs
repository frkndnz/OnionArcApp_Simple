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
    public class RoleRepository : GenericRepository<Role>,IRoleRepository
    {
        private readonly AppDbContext dbContext;

        public RoleRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Role?> GetByName(string name)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(r => r.RoleName == name);
        }
    }
}
