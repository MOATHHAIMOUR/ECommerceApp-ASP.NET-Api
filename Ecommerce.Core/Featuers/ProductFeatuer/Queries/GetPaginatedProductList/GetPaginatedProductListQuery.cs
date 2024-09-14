using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Common.Helpers;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using MediatR;

namespace Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList
{
    public class GetPaginatedProductListQuery : IRequest<Response<PaginatedResult<ProductDTO>>>
    {

        public Dictionary<string, string> SotrsDic { set; get; } = new Dictionary<string, string>();
        public Dictionary<string, string> FiltersDic { set; get; }


        public int PageNumber { get; set; }
        public int PageSize { get; set; }


        public GetPaginatedProductListQuery(string sotrs, string filters, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SotrsDic = UtilityHelper.ConstructDic(sotrs);
            FiltersDic = UtilityHelper.ConstructDic(filters);
        }
    }
}
