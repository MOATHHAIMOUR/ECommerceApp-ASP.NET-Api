using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.Results;
using MediatR;

namespace Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.SignIn
{
    public class SignInCommand : IRequest<Response<AuthenticatedResult>>
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
