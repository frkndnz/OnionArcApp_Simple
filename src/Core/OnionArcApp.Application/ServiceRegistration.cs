
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnionArcApp.Application.Features.ProductOperations.Commands.CreateProduct;
using OnionArcApp.Application.Interfaces.AccountService;
using OnionArcApp.Application.Services;

namespace OnionArcApp.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            var assm = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(assm);
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assm));

            services.AddValidatorsFromAssemblyContaining<CreateProductValidator>();
            services.AddScoped<IAccountService, AccountService>();
        }
    }
}
