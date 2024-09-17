
using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Results;
using MediatR;

namespace Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.RefreshToken
{
    public class RefreshTokenCommandHandler : ResponseHandler, IRequestHandler<RefreshTokenCommand, Response<AuthenticatedResult>>
    {
        public Task<Response<AuthenticatedResult>>
            Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {





        }
    }
}
