using JourneyJoy.DAL.Abstract;
using JourneyJoy.DAL.Concrete;
using JourneyJoy.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace JourneyJoy.DAL.Repositories
{
    public class GenericRepository<T>(AppDbContext context) : IGenericDAL<T> where T : class, IEntityBase, new()
    {
        internal DbSet<T> dbSet = context.Set<T>();
        private async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
        public IQueryable<T> QueryWithIncludes(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = dbSet;
            return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        }
        public async Task AddAsync(T entity)
        {
            await dbSet.AddAsync(entity);
            await SaveChangesAsync();
        }

        public void Delete(int id)
        {
            var value = dbSet.Find(id); // that control will check in Business layer
            dbSet.Remove(value);
            context.SaveChanges();
        }

        public IEnumerable<T> GetAll() => [.. QueryWithIncludes()];

        public async Task<IEnumerable<T>> GetAllAsync() => await QueryWithIncludes().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter) => await QueryWithIncludes().Where(filter).ToListAsync();

        public T GetById(int id) => dbSet.AsNoTracking().FirstOrDefault(x => x.Id == id);

        public async Task<T> GetByIdAsync(int id) => await dbSet.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

        public void Update(T entity)
        {
            EntityEntry entityEntry = context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            context.SaveChanges();
        }

        public async Task<T> GetByFilter(Expression<Func<T, bool>> filter) => await QueryWithIncludes().FirstOrDefaultAsync(filter);
    }
}
