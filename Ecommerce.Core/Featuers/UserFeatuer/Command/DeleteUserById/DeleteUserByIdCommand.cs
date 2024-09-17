using Ecommerce.Application.Common.BaseResponse;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.DeleteUserById
{
    public class DeleteUserByIdCommand : IRequest<Response<object>>
    {
        public DeleteUserByIdCommand(int userId)
        {
            this.userId = userId;
        }

        public int userId { set; get; }
    }
}
