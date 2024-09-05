using AutoMapper;
using Ecommerce.Domain.Entites;


namespace Ecommerce.Application.Featuers.ProductFeatuer.Queries
{
    // DTO for displaying product information
    public class ProductDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public string CategoryName { get; set; }


        public class ProductProfile : Profile
        {
            public ProductProfile()
            {
                CreateMap<Product, ProductDTO>().ReverseMap();
            }
        }
    }

}
