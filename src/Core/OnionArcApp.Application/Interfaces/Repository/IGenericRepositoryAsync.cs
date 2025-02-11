using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using OnionArcApp.Domain.Common;
using OnionArcApp.Domain.Entities;

namespace OnionArcApp.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T:BaseEntity
    {
        Task<T> AddAsync(T entity);
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(Guid Id);
        Task<T> GetByIdIncludesAsync(Guid Id,Expression<Func<T,object>> include);

        Task<List<T>> GetAllIncludesAsyncs(Expression<Func<T,object>> include);
       
    }
}
