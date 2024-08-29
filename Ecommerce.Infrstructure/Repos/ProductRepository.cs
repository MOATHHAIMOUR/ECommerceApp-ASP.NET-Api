using Ecommerce.Core.Entites;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;

namespace Ecommerce.Infrstructure.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductrRepository
    {
        #region Fields
        private readonly AppDbContext _appDbContext;
        #endregion


        #region Constructors
        public ProductRepository(AppDbContext dbContext) : base(dbContext)
        {
            _appDbContext = dbContext;
        }
        #endregion


        #region Handles Functions
        #endregion
    }
}
