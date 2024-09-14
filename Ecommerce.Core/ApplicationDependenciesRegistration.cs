using Ecommerce.Application.Common.Behavioures;
using Ecommerce.Application.Services.AuthenticationServices;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Helpers;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace Ecommerce.Domain
{
    public static class ApplicationDependenciesRegistration
    {
        public static IServiceCollection RegisterApplicationDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            // Configuration for MediaR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            // Configuration for AutoMapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Validators Config
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));


            //Auth Config
            var jwtSettings = configuration.GetSection(nameof(JWTSettings)).Get<JWTSettings>();
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidAudience = jwtSettings.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key))
                };
            });



            // Configuration Services
            services.AddScoped<IProductServices, ProductServices>();
            services.AddScoped<IUserServices, UserServices>();
            services.AddScoped<IAuthServices, AuthServices>();


            return services;
        }
    }
}
