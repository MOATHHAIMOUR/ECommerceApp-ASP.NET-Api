using Ecommerce.Core.Interfaces;
using Ecommerce.Infrstructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Ecommerce.Infrstructure.Repos
{
    public class GenericRepository<TEntity> : IGeneericRepoositry<TEntity> where TEntity : class
    {

        private AppDbContext _context;
        private DbSet<TEntity> dbSet;

        public GenericRepository(AppDbContext context)
        {
            this._context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity Entity)
        {
            await dbSet.AddAsync(Entity);
        }

        public async Task<TEntity> GetById(int ID, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
         
            foreach (var includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.AsNoTracking().FirstOrDefaultAsync(entity => EF.Property<int>(entity, "Id").Equals(ID));
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "")
        {
                IQueryable<TEntity> query = dbSet;

                if (filter != null)
                {
                    query = query.Where(filter);
                }

                foreach (var includeProperty in includeProperties.Split
                    (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }

                if (orderBy != null)
                {
                    return await orderBy(query).AsNoTracking().ToListAsync();
                }
                else
                {
                    return await query.AsNoTracking().ToListAsync();
                }
        }

        public Task UpdateAsync(TEntity Entity)
        {
            dbSet.Attach(Entity);
            _context.Entry(Entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entityToDelete)
        {
            if (_context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }

            dbSet.Remove(entityToDelete);
           
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int ID)
        {
            TEntity entityToDelete = dbSet.Find(ID);
            
            dbSet.Remove(entityToDelete);

            return Task.CompletedTask; 
        }
    }
}
