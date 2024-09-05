using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories.Base;
using System.Linq.Expressions;

namespace Ecommerce.Domain.IRepositories
{
    public interface IProductrRepository : IGeneericRepoositry<Product>
    {
        public IQueryable<Product> GetById(int productId, params Expression<Func<Product, object>>[] Includes);

        public Task<bool> IsExist(int Id);
    }
}
