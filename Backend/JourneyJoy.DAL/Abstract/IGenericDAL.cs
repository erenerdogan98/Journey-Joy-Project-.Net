using JourneyJoy.Entities;
using System.Linq.Expressions;

namespace JourneyJoy.DAL.Abstract
{
    public interface IGenericDAL<T> where T : class, IEntityBase, new()
    {
        Task AddAsync(T entity);
        void Delete(int id);
        void Update(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        IEnumerable<T> GetAll();
        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<T> GetByFilter(Expression<Func<T, bool>> filter);
    }
}
