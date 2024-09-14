using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Application.Featuers.UserFeatuer.Queries.GetUserById;

public class GetUserByIdQuery : IRequest<Response<UserDTO>>
{

    [Required]
    public int UserId { get; set; }
    public GetUserByIdQuery(int userId)
    {
        UserId = userId;
    }
}
