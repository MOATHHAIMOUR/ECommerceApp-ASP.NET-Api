using Ecommerce.Domain.Entites;
using Microsoft.AspNetCore.Identity;

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
            return _userManager.Users;
        }

        public async Task<IdentityResult> AddNewUser(User user)
        {
            return await _userManager.CreateAsync(user);

        }


    }
}
