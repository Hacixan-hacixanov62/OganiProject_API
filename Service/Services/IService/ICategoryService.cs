
using Service.Dtos.Admin.CategoryDtos;

namespace Service.Services.IService
{
    public interface ICategoryService
    {
        Task CreateAsync(CategoryCreateDto model);
        Task EditAsync(int id,CategoryEditDto model);
        Task DeleteAsync(int id);
        Task<IEnumerable<CategoryDto>> GetAllAsync();
        Task<CategoryDto> GetByIdAsync(int id);
      //  Task<PaginationResponse<CategoryDto>> GetPaginateAsync(int page, int take);
       // Task<Dictionary<string, int>> GetCategoryProductCountsAsync();
    }
}
