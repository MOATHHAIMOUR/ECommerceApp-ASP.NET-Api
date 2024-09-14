using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Services.AuthenticationServices
{
    public interface IAuthServices
    {
        public Task<SignInResult> SignInUserAsync(User user, string password);

        public string GenerateJWTToken(User user);


    }
}
