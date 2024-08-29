using Ecommerce.Core.Interfaces;

namespace Ecommerce.Core
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoreyRepository {get;}

        public IProductrRepository ProductrRepository   {get;}

        public Task<int> CommitAsync();

    }
}