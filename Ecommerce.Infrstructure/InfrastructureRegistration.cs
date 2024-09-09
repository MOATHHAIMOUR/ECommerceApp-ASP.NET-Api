using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Domain.IRepositories.Base;
using Ecommerce.Infrastructure.Repos.Base;
using Ecommerce.Infrstructure.Data;
using Ecommerce.Infrstructure.RepositroryImplemntation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrstructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructureConfiguration(this IServiceCollection services
            , IConfiguration configuration)
        {

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLServer"));
            });


            services.AddIdentity<User, IdentityRole<int>>(option =>
             {
                 // Password settings.
                 option.Password.RequireDigit = true;
                 option.Password.RequireLowercase = true;
                 option.Password.RequireNonAlphanumeric = true;
                 option.Password.RequireUppercase = true;
                 option.Password.RequiredLength = 6;
                 option.Password.RequiredUniqueChars = 1;

                 // Lockout settings.
                 option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                 option.Lockout.MaxFailedAccessAttempts = 5;
                 option.Lockout.AllowedForNewUsers = true;

                 // User settings.
                 option.User.AllowedUserNameCharacters =
                 "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                 option.User.RequireUniqueEmail = true;

                 option.SignIn.RequireConfirmedEmail = false;

             })
                 .AddEntityFrameworkStores<AppDbContext>()
                 .AddDefaultTokenProviders();

            services.AddScoped(typeof(IGeneericRepoositry<>), typeof(GenericRepository<>));

            services.AddScoped(typeof(IProductrRepository), typeof(ProductRepository));

            return services;
        }
    }
}
