using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Results;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using Ecommerce.Application.Services.ProductServices;
using MediatR;

namespace Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList
{
    public class GetPaginatedProductListQueryHandler : ResponseHandler, IRequestHandler<GetPaginatedProductListQuery, Response<PaginatedResult<ProductDTO>>>
    {
        private readonly IProductServices _productServices;

        public GetPaginatedProductListQueryHandler(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public async Task<Response<PaginatedResult<ProductDTO>>> Handle(GetPaginatedProductListQuery request, CancellationToken cancellationToken)
        {

            var result = await _productServices.GetAllProductsPaginatedAsync
                (Filters: request.FiltersDic,
                Ordering: request.SotrsDic,
                request.PageNumber,
                request.PageSize);

            var pagenatedResult = new PaginatedResult<ProductDTO>
                (true,
                result.Value,
                null,
                result.Value.Count,
                request.PageNumber,
                request.PageSize);

            return Success(pagenatedResult);
        }
    }
}