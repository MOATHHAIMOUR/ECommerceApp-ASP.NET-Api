using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.AddProduct
{
    internal class AddProductCommandHandler : ResponseHandler, IRequestHandler<AddProductCommand, Response<object>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public AddProductCommandHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<Response<object>> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            // mapping Between Request to Product object
            var Product = _mapper.Map<Product>(request);

            int Id = await _productServices.AddAsync(Product);

            if (Id > 0)
            {
                return Created<object>(Id, $"Product Add Succesfully With Id: {Id}");
            }
            else
            {
                return BadRequest<object>("There was an error");
            }

        }
    }
}
