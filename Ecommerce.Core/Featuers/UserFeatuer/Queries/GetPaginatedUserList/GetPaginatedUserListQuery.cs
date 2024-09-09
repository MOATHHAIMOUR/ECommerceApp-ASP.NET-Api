using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Helpers;
using Ecommerce.Application.Common.pagination;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries.GetPaginatedUserList
{
    public class GetPaginatedUserListQuery : IRequest<Response<PaginatedResult<UserDTO>>>
    {
        public Dictionary<string, string> SotrsDic { set; get; } = new Dictionary<string, string>();
        public Dictionary<string, string> FiltersDic { set; get; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetPaginatedUserListQuery(string Sorts, string filters, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SotrsDic = Helpers.ConstructDic(Sorts);
            FiltersDic = Helpers.ConstructDic(filters);
        }
    }
}
