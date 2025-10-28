
using Domain.Comman;
using System.Linq.Expressions;

namespace Repository.Repositories.IRepositories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task CreateAsync(T entity);
        Task EditAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateRangeAsync(IEnumerable<T> entities);
        Task<IEnumerable<T>> GetAllWithExpressionAsync(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAllForPagination(Expression<Func<T, bool>> predicate);
        IQueryable<T> FindAllWithIncludes();

    }
}
