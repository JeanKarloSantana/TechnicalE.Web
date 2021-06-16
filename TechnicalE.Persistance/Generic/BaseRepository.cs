using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using TechnicalE.DAL.SQL;
using TechnicalE.Interfaces.Generic;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace TechnicalE.Persistance.Generic
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class 
    {
    
        protected TechnicalEvDbContext context { get; private set; }

        public BaseRepository(TechnicalEvDbContext dbContext)
        {
            context = dbContext;
        }

        public virtual TEntity Get(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).FirstOrDefault();
        }

        public virtual TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public virtual TEntity GetCompositeKey(int firstId, int secondId)
        {
            return context.Set<TEntity>().Find(firstId, secondId);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public virtual IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return context.Set<TEntity>().Where(predicate).ToList();
        }

        public virtual async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await context.Set<TEntity>().Where(predicate).FirstOrDefaultAsync();
        }

        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await context.Set<TEntity>().FindAsync(id);
        }


        public void Add(TEntity entity)
        {
            var entry = context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                context.Set<TEntity>().Add(entity);
            }
            else
            {
                entry.State = EntityState.Modified;
            }
        }

        public void AddAll(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                Add(entity);
            }
        }

        public void RefreshEntity(TEntity entity)
        {
            context.Entry<TEntity>(entity).Reload();
        }
    }
}
