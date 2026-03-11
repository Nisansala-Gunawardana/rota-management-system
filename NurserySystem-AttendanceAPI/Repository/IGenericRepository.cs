using NurserySystem_AttendanceAPI.Model;

namespace NurserySystem_AttendanceAPI.Repository
{
    public interface IGenericRepository<T,TKey> where T : BaseEntity<TKey>
    {
        Task<T?> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> FindAllAsync(System.Linq.Expressions.Expression<System.Func<T, bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
