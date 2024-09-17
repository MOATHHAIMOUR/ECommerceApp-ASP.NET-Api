using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.DeleteUserById
{
    public class DeleteUserByIdHandler : ResponseHandler, IRequestHandler<DeleteUserByIdCommand, Response<object>>
    {
        private readonly IUserServices _userServices;

        public DeleteUserByIdHandler(IUserServices userServices)
        {
            _userServices = userServices;
        }


        public async Task<Response<object>>
            Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
        {

            User UserToDelete = await _userServices.GetUserByIdAsync(request.userId);

            if (UserToDelete == null)
                return NotFound<object>($"User with id: {request.userId} is not found");

            IdentityResult result = await _userServices.DeleteUserAsync(UserToDelete);

            if (result.Succeeded)
                return Success<object>(message: "User Deleted Succsessfully");
            else
                return BadRequest<object>(string.Join(',', result.Errors.Select(e => e.Description).ToList()));
        }
    }
}
