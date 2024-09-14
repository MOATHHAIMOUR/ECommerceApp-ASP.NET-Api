using Ecommerce.Application.Common.BaseResponse;
using Ecommerce.Application.Common.BaseResponse.GenericApiResponse;
using Ecommerce.Application.Services.AuthenticationServices;
using Ecommerce.Application.Services.UserServices;
using Ecommerce.Domain.Entites;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Featuers.AuthenticationFeatuer.Command.SignIn
{
    public class SignInCommandHandler : ResponseHandler, IRequestHandler<SignInCommand, Response<AuthenticatedResult>>
    {

        private readonly IUserServices _userServices;
        private readonly IAuthServices _authenticationServices;

        public SignInCommandHandler(IUserServices userServices, IAuthServices authenticationServices)
        {
            _userServices = userServices;
            _authenticationServices = authenticationServices;
        }

        public async Task<Response<AuthenticatedResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            User user = _userServices.GetAllUsersAsQueryable()
                 .FirstOrDefault(u => u.UserName == request.Username);

            if (user == null)
                return NotFound<AuthenticatedResult>(message: $"user with username: {request.Username} is not found");

            SignInResult result = await _authenticationServices.SignInUserAsync(user, request.Password);

            if (!result.Succeeded)
                return Unauthorized<AuthenticatedResult>("Invalid User Name or Password");

            string token = _authenticationServices.GenerateJWTToken(user);

            return Success<AuthenticatedResult>(
                Meta: new AuthenticatedResult()
                {
                    UserId = user.Id.ToString(),
                    FullName = user.FullName,
                    Token = token,
                    TokenType = "Bearer",
                    Username = user.UserName,


                },
                message: "User Authenticated Succsessfully"
                );

        }
    }
}
