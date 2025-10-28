
using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.IRepositories;
using System;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class CategoryRepositroy : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepositroy(AppDbContext context) : base(context)
        {
        }

        //public IQueryable<Category> GetAllWithExpression(Expression<Func<Category, bool>> predicate)
        //{
        //    predicate ??= x => true;
        //    return _context.Categories.Include(m => m.Products).Where(predicate);
        //}

        //public Task<Dictionary<string, int>> GetCategoryProductCountsAsync()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
