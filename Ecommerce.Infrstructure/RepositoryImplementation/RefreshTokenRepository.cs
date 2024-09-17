using Ecommerce.Domain.Entites.Identity;
using Ecommerce.Domain.IRepositories;
using Ecommerce.Infrastructure.Repos.Base;
using Ecommerce.Infrstructure.Data;

namespace Ecommerce.Infrastructure.RepositoryImplementation
{
    public class RefreshTokenRepository : GenericRepository<UserRefreshToken>, IRefreshTokenRepository
    {
        public RefreshTokenRepository(AppDbContext context) : base(context)
        {
        }
    }
}
