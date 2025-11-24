
using Repository.Repositories.IRepositories;
using Service.Dtos.Admin.ProductDtos;
using Service.Services.IService;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository, ICategoryRepository categoryRepository )
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public Task CreateAsync(ProductCreateDto model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteImageAsync(int productId, int productImageId)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDetailDto> DetailAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditAsync(int id, ProductEditDto model)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> FilterAsync(string categoryName, string colorName, string tagName, string brandName)
        {
            throw new NotImplementedException();
        }

        public Task<List<ProductDto>> FilterByPriceAsync(ProductFilterDto filterDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetAllTakenAsync(int take, int? skip = null)
        {
            throw new NotImplementedException();
        }

        public Task<ProductDto> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ProductWithImagesDto> GetByIdWithImagesAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetComparisonProductsAsync(int categoryId, int selectedProductId, int count = 3)
        {
            throw new NotImplementedException();
        }

        public Task<decimal> GetMaxPriceAsync()
        {
            throw new NotImplementedException();
        }

        public Task<int> GetProductsCountAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> GetSortedProductsAsync(string sortType)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> SearchByCategoryAndName(string categoryOrProductName)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductDto>> SearchByName(string name)
        {
            throw new NotImplementedException();
        }
    }
}
