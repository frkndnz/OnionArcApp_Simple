using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

using OnionArcApp.Application.Interfaces.Token;
using OnionArcApp.Application.Interfaces.UserPassword;
using OnionArcApp.Infrastructure.Services;

namespace OnionArcApp.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<ITokenHandler, TokenHandler>();
            services.AddTransient<IPasswordService, PasswordService>();
            services.AddTransient<IPasswordHasher<object>, PasswordHasher<object>>();
        }
    }
}
