using Delivery.DAL.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Delivery.DAL
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected readonly DeliveryContextFactory _contextFactory;
        protected readonly DbSet<T> _dbSet;

        public BaseRepository(DeliveryContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public virtual IEnumerable<T> GetAll()
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Set<T>().ToList();
            }
        }

        public virtual IQueryable<T> GetAllAsync()
        {
            using (var context = _contextFactory.GetContext())
            {
                return context.Set<T>().AsQueryable();
            }
        }

        public virtual T Get(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                var _dbSet = context.Set<T>();
                return _dbSet.Find(id) as T;
            }
        }

        public virtual async Task<T> GetAsync(int id)
        {
            var _dbSet = _contextFactory.GetContext().Set<T>();
            return await _dbSet.FindAsync(id);
        }

        public virtual void Create(T item)
        {
            using (var context = _contextFactory.GetContext())
            {
                var _dbSet = context.Set<T>();
                _dbSet.Add(item);
                context.SaveChanges();
            }
        }

        public virtual async Task CreateAsync(T item)
        {
            using (var context = _contextFactory.GetContext())
            {
                var _dbSet = context.Set<T>();
                await _dbSet.AddAsync(item);
                await context.SaveChangesAsync();
            }
        }

        public virtual void Update(T item)
        {
            using (var context = _contextFactory.GetContext())
            {
                context.Entry(item).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public virtual async Task UpdateAsync(T item)
        {
            using (var context = _contextFactory.GetContext())
            {
                context.Update(item);
                await context.SaveChangesAsync();
            }
        }

        public virtual void Delete(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                var _dbSet = context.Set<T>();
                T item = _dbSet.Find(id);
                if (item != null)
                    _dbSet.Remove(item);
                context.SaveChanges();
            }
        }

        public virtual async Task DeleteAsync(int id)
        {
            using (var context = _contextFactory.GetContext())
            {
                var _dbSet = context.Set<T>();
                T item = await _dbSet.FindAsync(id);
                if (item != null)
                {
                    _dbSet.Remove(item);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}
