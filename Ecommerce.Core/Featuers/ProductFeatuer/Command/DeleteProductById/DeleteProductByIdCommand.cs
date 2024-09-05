using Ecommerce.Application.Common.BaseResponse;
using MediatR;

namespace Ecommerce.Application.Featuers.ProductFeatuer.Command.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<object>>
    {
        public int Id { get; set; }
    }
}
