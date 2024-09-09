using Ecommerce.Domain.Entites;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Infrastructure.Repos.Base;
using Ecommerce.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infrastructure.RepositoryImplementation
{
    public class UserRepositort : GenericRepository<User>, IUserRepository
    {

        private readonly DbSet<User> _users;

        public UserRepositort(AppDbContext _dbContext) : base(_dbContext)
        {
            _users = _dbContext.Set<User>();
        }
    }
}
