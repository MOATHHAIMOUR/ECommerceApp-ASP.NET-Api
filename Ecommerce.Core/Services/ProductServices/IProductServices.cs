using Ecommerce.Domain.Entites;
using System.Linq.Expressions;

namespace Ecommerce.Application.Services.ProductServices
{
    public interface IProductServices
    {
        public IQueryable<Product> GetAllProductsAsQurable(params Expression<Func<Product, object>>[] Includes);

        public IQueryable<Product> GetProductById(int Id);

        //public IQueryable<Product> FilterStudentPaginatedQueryable(string search, string[] orderBy);

        public Task<int> AddAsync(Product product);

        public Task<bool> UpdateAsync(Product product);

        public Task<bool> DeleteAsync(Product product);

        public Task<bool> IsExist(int id);



    }
}
