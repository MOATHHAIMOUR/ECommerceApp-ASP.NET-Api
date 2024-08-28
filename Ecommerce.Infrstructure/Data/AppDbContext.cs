using Ecommerce.Core.Entites;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Infrstructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public virtual DbSet<Category> Categories { get; set; } 

        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        }
    }
}
