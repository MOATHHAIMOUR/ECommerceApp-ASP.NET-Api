using Ecommerce.Core;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;
using Ecommerce.Infrstructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Ecommerce.Infrstructure
{
    public static class InfrastructureRegistration
    {
        public static IServiceCollection InfrastructuerConfiguration(this IServiceCollection services
            ,IConfiguration configuration) 
        {
            services.AddScoped(typeof(IGeneericRepoositry<>), typeof(GenericRepository<>));

            /* services.AddScoped<ICategoreyRepository, CategoreyRepository>();

             services.AddScoped<IProductrRepository, ProductRepository>();*/

            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SQLServer")); 
            });

            return services; 
        }
    }
}
