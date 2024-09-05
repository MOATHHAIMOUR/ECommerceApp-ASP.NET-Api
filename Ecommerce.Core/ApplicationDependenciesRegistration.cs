using Ecommerce.Application.Common.Behavioures;
using Ecommerce.Application.Services.ProductServices;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Ecommerce.Domain
{
    public static class ApplicationDependenciesRegistration
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services)
        {
            // Configuration for MediaR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Configuration Services
            services.AddScoped<IProductServices, ProductServices>();

            // Get Validators
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            return services;
        }
    }
}
