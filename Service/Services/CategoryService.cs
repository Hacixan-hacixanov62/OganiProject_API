
using AutoMapper;
using Azure;
using Domain.Entites;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Repository.Repositories.IRepositories;
using Service.Dtos.Admin.CategoryDtos;
using Service.Services.IService;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task CreateAsync(CategoryCreateDto model)
        {
            var categoryExists = await _categoryRepository.GetAllWithExpressionAsync(x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower());
            if (categoryExists.ToList().Count > 0) throw new ArgumentException("This category has already exist");
            
            Category category = _mapper.Map<Category>(model);

            await _categoryRepository.CreateAsync(category);
        }

        public async Task DeleteAsync(int id)
        {
            Category category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException($"Category with ID {id} not found.");

            await _categoryRepository.DeleteAsync(category);
        }

        public async Task EditAsync(int id,CategoryEditDto model)
        {
            Category existCategory = await _categoryRepository.GetByIdAsync(id);
            if(existCategory == null)
            {
                throw new KeyNotFoundException($"Category with Id {id} Not Found");
            }


            if (!string.Equals(existCategory.Name.Trim(), model.Name.Trim(), StringComparison.OrdinalIgnoreCase))
            {
                var sameNameCategory = await _categoryRepository
                    .GetAllWithExpressionAsync(x => x.Name.Trim().ToLower() == model.Name.Trim().ToLower() && x.Id != id);

                if (sameNameCategory.Any())
                    throw new ArgumentException("This category name already exists.");
            }

            _mapper.Map(model, existCategory);
            await _categoryRepository.EditAsync(existCategory);
        }

        public async Task<IEnumerable<CategoryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CategoryDto>>(await _categoryRepository.GetAllAsync());
        }

        public async Task<CategoryDto> GetByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            if (category == null) throw new KeyNotFoundException($"Category with ID {id} not found.");
            return _mapper.Map<CategoryDto>(category);
        }

        //public async Task<Dictionary<string, int>> GetCategoryProductCountsAsync()
        //{
        //    var products = _categoryRepository.GetAllWithExpression(null);
        //    int totalItemCount = products.Count();

        //    var paginated = products
        //        .Skip((page - 1) * take)
        //        .Take(take)
        //        .ToList();

        //    var mappedDatas = _mapper.Map<IEnumerable<CategoryDto>>(paginated);

        //    int totalPage = (int)Math.Ceiling((decimal)totalItemCount / take);

        //    return new PaginationResponse<CategoryDto>(mappedDatas, totalPage, page, totalItemCount);
        //}
    }
}
