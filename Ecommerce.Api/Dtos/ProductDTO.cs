using Ecommerce.Core.Entites;

namespace Ecommerce.Api.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal  Price { get; set; } 
        public string CategoryName { get; set; } 

        public ProductDTO ToProductDTO(Product product)
        {
            return new ProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                CategoryName = product.Category.Name,
            }; 
        }
    }
}
