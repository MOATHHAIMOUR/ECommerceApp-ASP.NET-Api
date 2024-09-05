using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Ecommerce.Infrstructure.Data
{
    public class AppDbContext : IdentityDbContext<User,IdentityRole<int>, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>> 
    { 
       
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

        public  DbSet<User> Users {  get; set; } 
        
        public  DbSet<Category> Categories { get; set; } 

        public  DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());  
        }
    }
}
