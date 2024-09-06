using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Extentions;
using Ecommerce.Application.Common.pagination;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using Ecommerce.Application.Services.ProductServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList
{
    public class GetPaginatedProductListQueryHandler : ResponseHandler, IRequestHandler<GetPaginatedProductListQuery, Response<PaginatedResult<ProductDTO>>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public GetPaginatedProductListQueryHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<Response<PaginatedResult<ProductDTO>>>
            Handle(GetPaginatedProductListQuery request, CancellationToken cancellationToken)
        {

            var query = _productServices
                .GetAllProductsAsQurable(product => product.Category)
                .ToPaginated(request.PageNumber, request.PageSize)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider)
                .CustomFiltering(request.FiltersDic)
                .CustomOrdering(request.SotrsDic);

            Console.WriteLine("Final Query Result");
            Console.WriteLine(query.ToQueryString());


            var ProductList = await query.ToListAsync();

            var pagenatedResult = new PaginatedResult<ProductDTO>
                (true, ProductList, null, ProductList.Count, request.PageNumber, request.PageSize);

            return Success(pagenatedResult);
        }
    }
}