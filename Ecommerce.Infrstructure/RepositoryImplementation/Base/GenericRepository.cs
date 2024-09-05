using Ecommerce.Domain.IRepositories.Base;
using Ecommerce.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;


namespace Ecommerce.Infrastructure.Repos.Base
{
    public class GenericRepository<TEntity> : IGeneericRepoositry<TEntity> where TEntity : class
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext context)
        {
            _dbContext = context;
        }

        public IQueryable<TEntity> GetTableNoTracking(params Expression<Func<TEntity, object>>[] Includes)
        {
            IQueryable<TEntity> query = _dbContext.Set<TEntity>().AsNoTracking().AsQueryable();


            foreach (var include in Includes)
            {
                query = query.Include(include);
            }

            return query;
        }

        public IQueryable<TEntity> GetTableAsTracking()
        {
            return _dbContext.Set<TEntity>().AsQueryable();

        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public virtual async Task AddRangeAsync(ICollection<TEntity> entities)
        {
            await _dbContext.Set<TEntity>().AddRangeAsync(entities);
            await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            var AddEnttiy = await _dbContext.Set<TEntity>().AddAsync(entity);

            await _dbContext.SaveChangesAsync();

            return AddEnttiy.Entity;
        }

        public virtual async Task<bool> UpdateAsync(TEntity entity)
        {
            _dbContext.Update<TEntity>(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }
        public virtual async Task<bool> DeleteAsync(TEntity entity)
        {
            _dbContext.Set<TEntity>().Remove(entity);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public virtual async Task UpdateRangeAsync(ICollection<TEntity> entities)
        {
            _dbContext.Set<TEntity>().UpdateRange(entities);
            await _dbContext.SaveChangesAsync();
        }




        public virtual async Task DeleteRangeAsync(ICollection<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                _dbContext.Entry(entity).State = EntityState.Deleted;
            }
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public IDbContextTransaction BeginTransaction()
        {
            return _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            _dbContext.Database.CommitTransaction();
        }

        public void RollBack()
        {
            _dbContext.Database.RollbackTransaction();
        }

    }
}