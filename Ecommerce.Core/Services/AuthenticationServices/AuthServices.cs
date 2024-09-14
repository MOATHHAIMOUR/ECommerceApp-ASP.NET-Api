using Ecommerce.Domain.Entites;
using Ecommerce.Domain.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Ecommerce.Application.Services.AuthenticationServices
{
    public class AuthServices : IAuthServices
    {

        private readonly JWTSettings _jWTSettings;
        private readonly SignInManager<User> _signInManager;

        public AuthServices(JWTSettings jWTSettings, SignInManager<User> signInManager)
        {
            _jWTSettings = jWTSettings;
            _signInManager = signInManager;
        }

        public string GenerateJWTToken(User user)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims =
            [
                new Claim(JwtRegisteredClaimNames.Sub,user.UserName),
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
                new Claim("FullName",user.FullName),
                new Claim("Phone",user.PhoneNumber),
            ];

            var token = new JwtSecurityToken(
                issuer: _jWTSettings.Issuer,
                audience: _jWTSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jWTSettings.AccessTokenExpirationMinutes),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        public async Task<SignInResult> SignInUserAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }
    }
}
