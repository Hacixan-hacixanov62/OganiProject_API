
using Domain.Entites;
using System.Linq.Expressions;

namespace Repository.Repositories.IRepositories
{
    public interface ICategoryRepository :IBaseRepository<Category>
    {
        //IQueryable<Category> GetAllWithExpression(Expression<Func<Category, bool>> predicate);
        //Task<Dictionary<string, int>> GetCategoryProductCountsAsync();
    }
}
