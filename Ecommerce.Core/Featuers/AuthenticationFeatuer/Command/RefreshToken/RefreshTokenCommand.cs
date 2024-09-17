using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Results;
using MediatR;

namespace Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.RefreshToken
{
    public class RefreshTokenCommand : IRequest<Response<AuthenticatedResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

    }
}
