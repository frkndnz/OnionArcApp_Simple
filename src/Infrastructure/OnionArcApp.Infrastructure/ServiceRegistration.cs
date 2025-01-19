using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

using OnionArcApp.Application.Interfaces.Token;
using OnionArcApp.Infrastructure.Services;

namespace OnionArcApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<ITokenHandler, TokenHandler>();
        }
    }
}
