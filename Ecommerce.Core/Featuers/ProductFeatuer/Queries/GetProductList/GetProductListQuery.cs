using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using MediatR;

namespace Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<Response<List<ProductDTO>>>
    {

    }
}
