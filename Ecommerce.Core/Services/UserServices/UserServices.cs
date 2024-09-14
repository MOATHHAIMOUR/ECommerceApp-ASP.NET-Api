using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Application.Services.UserServices
{
    public class UserServices : IUserServices
    {

        private readonly UserManager<User> _userManager;


        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public IQueryable<User> GetAllUsersAsQueryable()
        {
            return _userManager.Users.AsNoTracking();
        }

        public async Task<IdentityResult> AddNewUser(User user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<IdentityResult> UpdateUser(User user)
        {
            return await _userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> DeleteUserAsync(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task<IdentityResult> UpdateUserPasswordAsync(User user, string currentPassword, string newPassword)
        {
            return await _userManager.ChangePasswordAsync(user, currentPassword, newPassword);
        }
    }
}
