using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entites.Identity
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

        public ICollection<UserRefreshToken> RefreshTokens { get; set; }

    }
}
