using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.AddProduct
{
    public class AddProductCommand : IRequest<Response<object>>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<AddProductCommand, Product>();
            }
        }
    }
}
