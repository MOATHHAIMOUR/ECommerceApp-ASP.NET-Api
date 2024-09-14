using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Featuers.UserFeatuer.Command.UpdateUserById
{
    public class UpdateUserByIdCommandHandler : ResponseHandler, IRequestHandler<UpdateUserbyIdCommand, Response<object>>
    {
        private readonly IMapper _mapper;
        private readonly IUserServices _userServices;

        public UpdateUserByIdCommandHandler(IMapper mapper, IUserServices userServices)
        {
            _mapper = mapper;
            _userServices = userServices;
        }

        public async Task<Response<object>>
            Handle(UpdateUserbyIdCommand request, CancellationToken cancellationToken)
        {

            User oldUser = await _userServices.GetUserByIdAsync(request.Id);

            if (oldUser == null)
                return NotFound<object>($"User with id: {request.Id} is not found");

            IdentityResult result = await _userServices.UpdateUser(_mapper.Map(request, oldUser));

            if (result.Succeeded)
                return Created<object>("User Updated Succsessfully");
            else
                return BadRequest<object>(string.Join(',', result.Errors.Select(e => e.Description).ToList()));

        }
    }
}

