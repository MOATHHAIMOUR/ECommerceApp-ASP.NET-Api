using Ecommerce.Core.Entites;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;

namespace Ecommerce.Infrstructure.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductrRepository
    {
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
        }
    }
}
