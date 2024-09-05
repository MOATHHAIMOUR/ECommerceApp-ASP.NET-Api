using Ecommerce.Domain.Entites;

namespace Ecommerce.Application.Services.ProductServices
{
    public interface IProductServices
    {
        public IQueryable<Product> GetAllProducts();

        public IQueryable<Product> GetProductById(int Id);

        public Task<int> AddAsync(Product product);

        public Task<bool> UpdateAsync(Product product);

        public Task<bool> DeleteAsync(Product product);

        public Task<bool> IsExist(int id);

    }
}
