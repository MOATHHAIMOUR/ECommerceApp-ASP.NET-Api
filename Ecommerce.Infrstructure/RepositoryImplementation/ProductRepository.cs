using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Infrastructure.Repos.Base;
using Ecommerce.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrstructure.RepositroryImplemntation
{
    public class ProductRepository : GenericRepository<Product>, IProductrRepository
    {
        private readonly DbSet<Product> _products;

        public ProductRepository(AppDbContext _dbContext) : base(_dbContext)
        {
            _products = _dbContext.Set<Product>();
        }

        public IQueryable<Product> GetById(int productId, params Expression<Func<Product, object>>[] Includes)
        {
            IQueryable<Product> query = _products.Where(P => P.Id == productId);

            foreach (var Include in Includes)
            {
                query = query.Include(Include);
            }

            return query;
        }

        public async Task<bool> IsExist(int Id)
        {
            return await _products.AsNoTracking().AnyAsync(p => p.Id == Id);
        }
    }
}
