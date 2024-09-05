using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Services.ProductServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Queries.GetProductById
{
    public class GetProductByIdHandler : ResponseHandler, IRequestHandler<GetProductByIdQuery, Response<ProductDTO>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public GetProductByIdHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<Response<ProductDTO>>
            Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            ProductDTO productDTO = await _productServices.GetProductById(request.Id)
                .ProjectTo<ProductDTO>(_mapper.ConfigurationProvider).FirstOrDefaultAsync();

            if (productDTO == null)
                return NotFound<ProductDTO>($"Product with {request.Id} is not found!");

            return Success<ProductDTO>(productDTO);
        }
    }
}
