using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;

namespace Ecommerce.Application.Services.ProductServices
{
    public class ProductServices : IProductServices
    {

        private readonly IProductrRepository _productrRepository;


        public ProductServices(IProductrRepository productrRepository)
        {
            _productrRepository = productrRepository;
        }

        public IQueryable<Product> GetAllProducts()
        {
            return _productrRepository.GetTableNoTracking(include => include.Category);
        }

        public IQueryable<Product> GetProductById(int Id)
        {
            var Product = _productrRepository.GetById(Id, Include => Include.Category);
            return Product;
        }

        public async Task<int> AddAsync(Product product)
        {
            var Product = await _productrRepository.AddAsync(product);
            return Product.Id;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            return await _productrRepository.UpdateAsync(product);
        }

        public async Task<bool> IsExist(int id)
        {
            return await _productrRepository.IsExist(id);
        }

        public async Task<bool> DeleteAsync(Product product)
        {
            return await _productrRepository.DeleteAsync(product);
        }
    }
}
