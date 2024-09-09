using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices
    {
        public IQueryable<User> GetAllUsersAsQueryable();
        public Task<IdentityResult> AddNewUser(User user);
    }
}
