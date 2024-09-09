using AutoMapper;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Resources;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.AddUser
{
    public class AddUserCommandHandler : ResponseHandler, IRequestHandler<AddUserCommand, Response<object>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResources> _localizer;
        private readonly IUserServices _userServices;
        #endregion

        public AddUserCommandHandler(IMapper mapper, IStringLocalizer<SharedResources> localizer, IUserServices userServices)
        {
            _mapper = mapper;
            _localizer = localizer;
            _userServices = userServices;
        }

        public async Task<Response<object>>
            Handle(AddUserCommand request, CancellationToken cancellationToken)
        {

            User user = _mapper.Map<User>(request);

            IdentityResult result = await _userServices.AddNewUser(user);

            if (result.Succeeded)
            {
                return Created<object>(user.Id, "User Created Succsessfully");
            }
            else
            {
                return BadRequest<object>(result.Errors.ToString());
            }
        }
    }
}
