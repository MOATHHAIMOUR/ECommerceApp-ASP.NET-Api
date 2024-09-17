using Ecommerce.Application.Common.Results;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using Ecommerce.Domain.Entites;

namespace Ecommerce.Application.Services.ProductServices
{
    public interface IProductServices
    {
        public Task<Result<List<ProductDTO>>> GetAllProductsPaginatedAsync(Dictionary<string, string>? Filters, Dictionary<string, string>? Ordering, int PageNumber = 1, int PageSize = 10);
        public IQueryable<Product> GetProductById(int Id);

        public Task<int> AddAsync(Product product);

        public Task<bool> UpdateAsync(Product product);

        public Task<bool> DeleteAsync(Product product);

        public Task<bool> IsExist(int id);



    }
}
