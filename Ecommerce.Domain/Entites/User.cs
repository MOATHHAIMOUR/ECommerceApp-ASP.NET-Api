using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Domain.Entites
{
    public class User : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }

    }
}
