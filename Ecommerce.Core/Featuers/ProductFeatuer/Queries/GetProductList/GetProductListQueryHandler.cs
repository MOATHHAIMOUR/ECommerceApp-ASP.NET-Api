using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Featuers.ProductFeatuer.Queries;
using Ecommerce.Application.Services.ProductServices;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.Domain.Featuers.ProductFeatuer.Queries.GetProductList
{
    public class GetProductListQueryHandler : ResponseHandler, IRequestHandler<GetProductListQuery, Response<List<ProductDTO>>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public GetProductListQueryHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        async Task<Response<List<ProductDTO>>> IRequestHandler<GetProductListQuery, Response<List<ProductDTO>>>.Handle(GetProductListQuery request, CancellationToken cancellationToken)
        {
            //var ProductList = await  _productServices.FetchAllProducts()
            //    .Select(p => new ProductDTO
            //    {
            //        Id = p.Id,
            //        Name = p.Name,
            //        Description = p.Description,
            //        CategoryName = p.Category.Name,
            //        Price = p.Price,

            //    }).ToListAsync();

            var ProductList = await _productServices.GetAllProducts()
               .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).ToListAsync();

            return Success(ProductList, new { count = ProductList.Count });
        }
    }
}
