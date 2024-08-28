using Ecommerce.Core.Entites;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;

namespace Ecommerce.Infrstructure.Repos
{
    public class CategoreyRepository : GenericRepository<Category>, ICategoreyRepository
    {
        public CategoreyRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
