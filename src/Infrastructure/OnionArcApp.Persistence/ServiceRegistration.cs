using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using OnionArcApp.Application.Interfaces.Repository;
using OnionArcApp.Persistence.Context;
using OnionArcApp.Persistence.Repositories;

namespace OnionArcApp.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("memoryDb"));

            services.AddTransient<IProductRepository,ProductRepository>();
        }
    }
}
