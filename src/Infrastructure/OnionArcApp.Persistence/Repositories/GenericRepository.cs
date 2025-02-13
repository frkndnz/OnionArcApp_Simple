using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Domain.Common;
using OnionArcApp.Persistence.Context;

namespace OnionArcApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {
        private readonly AppDbContext dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await dbContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> GetAllIncludeAsync(Expression<Func<T, object>> include)
        {
            IQueryable<T> query = dbContext.Set<T>().Include(include);
            return await query.ToListAsync();
        }

        public async Task<List<T>> GetAllIncludesAsync(params Expression<Func<T, object>>[] include)
        {
            IQueryable<T> query = dbContext.Set<T>();
            foreach (var item in include)
            {
               query= query.Include(item);
            }
            return await query.ToListAsync();
        }

        public async Task<T?> GetByIdAsync(Guid Id)
        {
            return await dbContext.Set<T>().FindAsync(Id);
        }

        public async Task<T?> GetByIdIncludeAsync(Guid Id, Expression<Func<T, object>> include)
        {
            IQueryable<T> query = dbContext.Set<T>();

            query = query.Include(include);

            return await query.FirstOrDefaultAsync(u => u.Id == Id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            dbContext.Set<T>().Update(entity);
            await dbContext.SaveChangesAsync();
            return entity;
        }
    }
}
