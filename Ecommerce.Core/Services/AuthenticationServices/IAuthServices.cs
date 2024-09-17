using Ecommerce.Application.Common.Results;
using Ecommerce.Domain.Entites.Identity;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Services.AuthenticationServices
{
    public interface IAuthServices
    {
        public Task<SignInResult> SignInUserAsync(User user, string password);

        public string GenerateJWTToken(User user);

        public RefreshToken GenerateRefreshToken(User user);
    }
}
