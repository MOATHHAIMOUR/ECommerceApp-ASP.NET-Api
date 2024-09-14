using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.UpdateProductById
{
    public class UpdateProductHandler : ResponseHandler, IRequestHandler<UpdateProductByIdCommand, Response<object>>
    {

        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public UpdateProductHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<Response<object>>
            Handle(UpdateProductByIdCommand request, CancellationToken cancellationToken)
        {

            var IUpdated = await
                _productServices.UpdateAsync(_mapper.Map<Product>(request));

            if (IUpdated)
            {
                return Success<object>(message: "Product is Updated Successfully");
            }
            else
                return NotFound<object>($"Product With Id: {request.Id} is not found!");
        }
    }
}
