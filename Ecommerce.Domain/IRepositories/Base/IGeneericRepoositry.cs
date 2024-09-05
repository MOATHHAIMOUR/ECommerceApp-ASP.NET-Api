using System.Linq.Expressions;

namespace Ecommerce.Domain.IRepositories.Base
{
    public interface IGeneericRepoositry<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task DeleteRangeAsync(ICollection<TEntity> entities);
        Task SaveChangesAsync();
        IQueryable<TEntity> GetTableNoTracking(params Expression<Func<TEntity, object>>[] Includes);
        IQueryable<TEntity> GetTableAsTracking();
        Task<TEntity> AddAsync(TEntity entity);
        Task AddRangeAsync(ICollection<TEntity> entities);
        Task<bool> UpdateAsync(TEntity entity);
        Task UpdateRangeAsync(ICollection<TEntity> entities);
        Task<bool> DeleteAsync(TEntity entity);
        void Commit();
        void RollBack();

    }
}
