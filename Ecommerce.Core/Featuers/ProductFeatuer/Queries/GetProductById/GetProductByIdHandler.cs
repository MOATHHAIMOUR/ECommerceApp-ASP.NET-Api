using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Resources;
using Ecommerce.Application.Services.ProductServices;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Queries.GetProductById
{
    public class GetProductByIdHandler : ResponseHandler, IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
    {
        private readonly IProductServices _productServices;
        private readonly IStringLocalizer<SharedResources> _stringLocalizer;
        private readonly IMapper _mapper;


        public GetProductByIdHandler(IProductServices productServices, IStringLocalizer<SharedResources> stringLocalizer, IMapper mapper)
        {
            _productServices = productServices;
            _stringLocalizer = stringLocalizer;
            _mapper = mapper;
        }

        public async Task<Response<ProductDTO>>
            Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ProductDTO productDTO = await _productServices.GetProductById(request.Id)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            //$"Product with {request.Id} is not found!"
            if (productDTO == null)
                return NotFound<ProductDTO>(_stringLocalizer[SharedResourcesKeys.NotFound]);

            return Success<ProductDTO>(productDTO);
        }
    }
}
