using Ecommerce.Application.Common.Results;
using Ecommerce.Domain.Entites.Identity;
using Ecommerce.Domain.Helpers;
using Ecommerce.Domain.IRepositories;
using ErrorOr;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Ecommerce.Application.Services.AuthenticationServices
{
    public class AuthServices : IAuthServices
    {

        private readonly JWTSettings _jWTSettings;
        private readonly SignInManager<User> _signInManager;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;

        public AuthServices(JWTSettings jWTSettings, SignInManager<User> signInManager, IRefreshTokenRepository refreshTokenRepository, UserManager<User> userManager)
        {
            _jWTSettings = jWTSettings;
            _signInManager = signInManager;
            _refreshTokenRepository = refreshTokenRepository;
            _userManager = userManager;
        }

        public async Task<SignInResult> SignInUserAsync(User user, string password)
        {
            return await _signInManager.CheckPasswordSignInAsync(user, password, false);
        }

        public async Task<AuthenticatedResult> RefreshToken(string accessToken, string refreshToken)
        {
            //Read Token
            var jwtToekn = ReadJwtToken(accessToken);

            //cheek Alg Type
            if (jwtToekn == null || !jwtToekn.Header.Alg.Equals(SecurityAlgorithms.HmacSha256))
                return Result<AuthenticatedResult>.Failure("Alg Type is wrong");

            //cheek if token is still valied
            if (jwtToekn.ValidTo > DateTime.UtcNow)
                return Result<AuthenticatedResult>.Failure("Token is not Expired");

            var userRefreshToken = await _refreshTokenRepository.GetTableNoTracking().FirstOrDefaultAsync(
                u => u.AccessToken == refreshToken && u.RefreshToken == refreshToken);

            if (userRefreshToken == null)
                return Result<AuthenticatedResult>.Failure("refresh token not found");

            if (userRefreshToken.ExpiryDate < DateTime.UtcNow)
                return Result<AuthenticatedResult>.Failure("refresh token is expired");

            var user = await _userManager.FindByIdAsync(userRefreshToken.UserId.ToString()!);

            var toekn = GenerateJWTToken(user!);

            return Result<AuthenticatedResult>.Success(new AuthenticatedResult
            {
                AccessToken = WriteJWTToken(toekn),
                RefreshToken = GenerateRefreshToken()
            });
        }

        private JwtSecurityToken? ReadJwtToken(string accsessToken)
        {
            if (string.IsNullOrEmpty(accsessToken))
                return null;

            return new JwtSecurityTokenHandler().ReadJwtToken(accsessToken);
        }

        private static string WriteJWTToken(JwtSecurityToken token)
        {
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private ClaimsPrincipal? ValidateToken(JwtSecurityTokenHandler handler, string accessToken)
        {
            // Define the token validation parameters
            var parameters = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidIssuer = _jWTSettings.Issuer,
                ValidAudience = _jWTSettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Key)),
                ClockSkew = TimeSpan.Zero // Reduce the default 5 min clock skew for token expiration
            };

            try
            {
                // Validate the token and return the ClaimsPrincipal
                var claimsPrincipal = handler.ValidateToken(accessToken, parameters, out SecurityToken validatedToken);

                return claimsPrincipal;

            }
            catch (Exception ex) { }

            return null;
        }

        public async Task<(string AccsessToken, string RefreshToken)> GenerateAccessTokenAndRefreshTokenForUser(User user)
        {
            var AccsessToken = new JwtSecurityTokenHandler().WriteToken(GenerateJWTToken(user));

            var RefreshToken = GenerateRefreshToken();

            //save Refresh Token to DB 
            UserRefreshToken userRefreshToken = new UserRefreshToken
            {
                UserId = user.Id,
                CreatedAt = DateTime.UtcNow,
                AccessToken = AccsessToken,
                RefreshToken = RefreshToken,
                ExpiryDate = DateTime.UtcNow.AddDays(_jWTSettings.RefreshTokenExpirationDay),
                IsRevoked = false,
                IsUsed = true,
                JwtId = new Guid().ToString()
            };

            await _refreshTokenRepository.AddAsync(userRefreshToken);

            return (AccsessToken, RefreshToken);

        }

        private JwtSecurityToken GenerateJWTToken(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jWTSettings.Key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            Claim[] claims = GetCliams(user);

            var token = new JwtSecurityToken(
                issuer: _jWTSettings.Issuer,
                audience: _jWTSettings.Audience,
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jWTSettings.AccessTokenExpirationMinutes),
                signingCredentials: credentials
            );

            return token;
        }

        private static Claim[] GetCliams(User user)
        {
            return
            [
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("FullName", user.FullName),
                new Claim("Phone", user.PhoneNumber),
            ];
        }

        public string GenerateRefreshToken()
        {
            return GenerateRandomString();
        }

        private static string GenerateRandomString()
        {
            var randomNumber = new byte[32];
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                randomNumberGenerator.GetBytes(randomNumber);
            }
            return Convert.ToBase64String(randomNumber);
        }


    }

}
