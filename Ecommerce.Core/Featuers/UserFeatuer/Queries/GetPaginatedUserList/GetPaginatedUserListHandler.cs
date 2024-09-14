using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Common.Extentions;
using Ecommerce.Application.Services.UserServices;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries.GetPaginatedUserList
{
    public class GetPaginatedUserListHandler
        : ResponseHandler, IRequestHandler<GetPaginatedUserListQuery, Response<PaginatedResult<UserDTO>>>
    {

        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public GetPaginatedUserListHandler(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        public async Task<Response<PaginatedResult<UserDTO>>> Handle(GetPaginatedUserListQuery request, CancellationToken cancellationToken)
        {

            var users = await _userServices.GetAllUsersAsQueryable()
                .ToPaginated(request.PageNumber, request.PageSize)
                .ProjectTo<UserDTO>(_mapper.ConfigurationProvider)
                .CustomFiltering(request.FiltersDic)
                .CustomOrdering(request.SotrsDic)
                .ToListAsync();

            return Success(new PaginatedResult<UserDTO>(users));
        }
    }
}
