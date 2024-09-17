using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entites.Identity;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.ChangeUserPassword
{
    public class ChangeUserPasswordCommandHandler : ResponseHandler, IRequestHandler<ChangeUserPasswordCommand, Response<string>>
    {

        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public ChangeUserPasswordCommandHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<Response<string>>
            Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {

            User user = await _userServices.GetUserByIdAsync(request.Id);

            if (user == null)
                return NotFound<string>($"User with id: {request.Id} is not found");

            IdentityResult result = await _userServices.UpdateUserPasswordAsync(user, request.CurrentPassword, request.NewPassword);

            if (result.Succeeded)
                return Created<string>("Password Updated Succsessfully");
            else
                return BadRequest<string>(string.Join(',', result.Errors.Select(e => e.Description).ToList()));

        }
    }
}
