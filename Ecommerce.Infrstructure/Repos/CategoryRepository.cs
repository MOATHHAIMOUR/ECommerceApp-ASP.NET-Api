using Ecommerce.Core.Entites;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrstructure.Repos
{
    public class CategoreyRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly AppDbContext context;
        private DbSet<Category> _dbSet;

        public CategoreyRepository(AppDbContext dbContext) : base(dbContext)
        {
            this.context = dbContext;
            _dbSet = context.Categories; 
        }

     
    }
}
