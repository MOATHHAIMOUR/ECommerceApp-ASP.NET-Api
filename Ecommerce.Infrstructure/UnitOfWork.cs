using Ecommerce.Core;
using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;
using Ecommerce.Infrstructure.Repos;

namespace Ecommerce.Infrstructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICategoreyRepository CategoreyRepository { get; }

        public IProductrRepository ProductrRepository { get; }

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            
            CategoreyRepository = new CategoreyRepository(context);
            
            ProductrRepository = new ProductRepository(context);
        }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose(); 
        }
    }
}
