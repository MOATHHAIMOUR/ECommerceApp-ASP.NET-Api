using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Common.Helpers;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries.GetPaginatedUserList
{
    public class GetPaginatedUserListQuery : IRequest<Response<PaginatedResult<UserDTO>>>
    {
        public Dictionary<string, string> SotrsDic { set; get; }
        public Dictionary<string, string> FiltersDic { set; get; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedUserListQuery(string Sorts, string filters, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            if (!string.IsNullOrEmpty(filters))
                FiltersDic = UtilityHelper.ConstructDic(filters);

            if (!string.IsNullOrEmpty(Sorts))
                SotrsDic = UtilityHelper.ConstructDic(Sorts);
        }
    }
}
