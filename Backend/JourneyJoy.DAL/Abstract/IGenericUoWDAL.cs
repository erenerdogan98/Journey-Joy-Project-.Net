namespace JourneyJoy.DAL.Abstract
{
    public interface IGenericUoWDAL<T> where T : class
    {
        Task InsertAsync(T entity);
        void MultiUpdate(IEnumerable<T> entity);
        void Update(T entity);
        void Delete(T entity);
        Task<T> GetById(int id);
        Task<IEnumerable<T>> GetAll();
    }
}
