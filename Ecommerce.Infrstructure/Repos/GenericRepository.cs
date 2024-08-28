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

        public async Task<TEntity> FindAsync<TKey>(TKey ID, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
         
            foreach (var includeProperty in includeProperties.Split
                 (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            return await query.FirstOrDefaultAsync(entity => EF.Property<TKey>(entity, "Id").Equals(ID));
        }

        public async Task<IEnumerable<TEntity>> Get(
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

        public Task DeleteAsync<TKey>(TKey ID)
        {
            TEntity entityToDelete = dbSet.Find(ID);
            dbSet.Remove(entityToDelete);

            return Task.CompletedTask; 
        }
    }
}



/*
        public async Task AddAsync(T Entity)
        {
            await _context.Set<T>().AddAsync(Entity);            
        }

        public async Task DeleteAsync(T ID)
        {
            var entity = await _context.Set<T>().FindAsync(ID);
            
            if(entity!=null)
                _context.Set<T>().Remove(entity);
        }

        public async Task<IReadOnlyList<T>> GetAllAsync() => 
          await  _context.Set<T>().AsNoTracking().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _context.Set<T>().AsQueryable();

            //applay all Includes

            foreach (var item in Includes)
            {
                query  = query.Include(item);   
            }

            return await query.ToListAsync(); 
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<T,bool> predecate, params Expression<Func<T, object>>[] Includes)
        {
            IQueryable<T> query = _context.Set<T>().Where(predecate).AsQueryable();

            //applay all Includes

            foreach (var item in Includes)
            {
                query = query.Include(item);
            }

            return await query.ToListAsync();
        }


        public async Task<T> GetAsync(T ID)=> await _context.Set<T>().FindAsync(ID);
       
        public async Task UpdateAsync(T ID, T Entity)
        {
            var entity = await _context.Set<T>().FindAsync(ID);
            
            if (entity != null)
            {
                _context.Set<T>().Update(entity);
            }
        }

*/