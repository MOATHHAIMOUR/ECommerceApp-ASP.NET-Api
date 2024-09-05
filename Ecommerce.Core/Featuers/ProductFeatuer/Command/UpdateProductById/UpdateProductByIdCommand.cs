using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.UpdateProductById
{
    public class UpdateProductByIdCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        public class Mapping : Profile
        {
            public Mapping()
            {
                CreateMap<UpdateProductByIdCommand, Product>();
            }
        }
    }
}
