
using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OnionArcApp.Application.Features.ProductOperations.Commands.CreateProduct;

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
        }
    }
}
