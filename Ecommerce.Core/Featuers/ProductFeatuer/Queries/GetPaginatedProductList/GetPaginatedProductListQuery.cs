using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.pagination;
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
            SotrsDic = ConstructDic(sotrs);
            FiltersDic = ConstructDic(filters);
        }



        private Dictionary<string, string> ConstructDic(string sotrs)
        {

            Dictionary<string, string> keyValuePairs = new Dictionary<string, string>();
            // // Id DESE,Name DESE
            string[] SortsQuery = sotrs.Split(',');

            foreach (string SortQuery in SortsQuery)
            {
                // Id DESE
                string[] SortPerOrder = SortQuery.Split(' ');
                //Id
                string SortBy = SortPerOrder[0];
                //DESE
                string OrderBy = SortPerOrder[1];

                keyValuePairs.Add(SortBy, OrderBy);
            }

            return keyValuePairs;
        }



    }



}
