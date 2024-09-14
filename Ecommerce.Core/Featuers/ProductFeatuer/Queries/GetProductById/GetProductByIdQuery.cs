using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Queries.GetProductById
{
    public class GetProductByIdQuery : IRequest<Response<ProductDTO>>
    {
        [Required]
        public int Id { get; set; }
        public GetProductByIdQuery(int id)
        {
            Id = id;
        }
    }
}
