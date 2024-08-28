using System.Linq.Expressions;

namespace Ecommerce.Core.Interfaces
{
    public interface IGeneericRepoositry<TEntity> where TEntity : class
    {
        public Task AddAsync(TEntity Entity);
        
        public Task<TEntity> FindAsync<TKey>(TKey ID, string includeProperties = "");

        public Task<IEnumerable<TEntity>> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = ""); 

       
        public Task UpdateAsync(TEntity Entity);
        
        public Task DeleteAsync<TKey>(TKey ID);

        public Task DeleteAsync(TEntity entityToDelete); 
    }
}
