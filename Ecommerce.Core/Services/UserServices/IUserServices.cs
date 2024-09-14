using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Application.Services.UserServices
{
    public interface IUserServices
    {
        public IQueryable<User> GetAllUsersAsQueryable();

        public Task<IdentityResult> AddNewUser(User user, string password);

        public Task<User> GetUserByIdAsync(int userId);

        public Task<IdentityResult> UpdateUser(User user);

        public Task<IdentityResult> DeleteUserAsync(User user);

        public Task<IdentityResult> UpdateUserPasswordAsync(User user, string currentPassword, string newPassword);
    }
}
