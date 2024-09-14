﻿using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.Domain.Entites;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.DeleteProductById
{
    public class DeleteProductByIdHandler : ResponseHandler, IRequestHandler<DeleteProductByIdCommand, Response<object>>
    {
        private readonly IProductServices _productServices;
        private readonly IMapper _mapper;

        public DeleteProductByIdHandler(IProductServices productServices, IMapper mapper)
        {
            _productServices = productServices;
            _mapper = mapper;
        }

        public async Task<Response<object>>
            Handle(DeleteProductByIdCommand request,
            CancellationToken cancellationToken)
        {

            bool IsDeleted =
                 await _productServices.DeleteAsync(new Product { Id = request.Id });

            //message: $"Product With Id: {request.Id} Is Deleted Succsessfully"
            if (IsDeleted)
                return Deleted<object>($"Product With Id: {request.Id} Is Deleted Succsessfully");
            else
                return NotFound<object>($"The Product With Id: {request.Id} Is Not Found!");
        }
    }
}
