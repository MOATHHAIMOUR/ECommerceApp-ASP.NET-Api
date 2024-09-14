using AutoMapper;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Services.UserServices;
using MediatR;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries.GetUserById
{
    public class GetUserByIdHandler : ResponseHandler, IRequestHandler<GetUserByIdQuery, Response<UserDTO>>
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public GetUserByIdHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }
        public async Task<Response<UserDTO>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userServices.GetUserByIdAsync(request.UserId);

            if (user == null)
            {
                return NotFound<UserDTO>($"user with id:{request.UserId} is not found");
            }

            var userDTO = _mapper.Map<UserDTO>(user);
            return Success(userDTO, message: "User Retrived Succsesfully");
        }
    }
}
