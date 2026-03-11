using NurserySystem_HRWebAPI.Model;
using System.Linq.Expressions;

namespace NurserySystem_HRWebAPI.Repository
{
    public interface IGenericRepository<T,TKey> where T : BaseEntity<TKey>
    {
       
        Task<T?> GetByIdAsync(TKey id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includes);
        Task<IEnumerable<T>> FindAllAsync(System.Linq.Expressions.Expression<System.Func<T,bool>> predicate);
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();

    }
}
