using Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Repository.Data;
using Repository.Repositories.IRepositories;
using System.Linq.Expressions;

namespace Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {
        }

        public void Delete(ProductImage image)
        {
            _context.ProductImages.Remove(image);
        }

        public async Task DeleteProductImage(ProductImage image)
        {
            _context.Remove(image);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> FilterAsync(string categoryName, string colorName, string tagName, string brandName)
        {
            var query = GetAllWithIncludes();
            if (!string.IsNullOrEmpty(categoryName))
            {
                query = query.Where(p => p.Category.Name.ToLower() == categoryName.ToLower());
            }

            //if (!string.IsNullOrEmpty(colorName))  burdaki modelleri yaznada acarsan 
            //{
            //    query = query.Where(p => p.ProductColors.Any(pc => pc.Color.Name.ToLower() == colorName.ToLower()));
            //}

            //if (!string.IsNullOrEmpty(tagName))
            //{
            //    query = query.Where(p => p.ProductTags.Any(pt => pt.Tag.Name.ToLower() == tagName.ToLower()));
            //}

            //if (!string.IsNullOrEmpty(brandName))
            //{
            //    query = query.Where(p => p.Brand.Name.ToLower() == brandName.ToLower());
            //}

            return await query.ToListAsync();
        }

        public async Task<List<Product>> FilterByPriceAsync(decimal? minPrice, decimal? maxPrice)
        {
            var query = _context.Products.Include(m => m.Category).AsQueryable();
            if (minPrice.HasValue)
                query = query.Where(p => p.Price >= minPrice.Value);

            if (maxPrice.HasValue)
                query = query.Where(p => p.Price <= maxPrice.Value);

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllTakenAsync(int take, int? skip = null)
        {
           var query = _context.Products.Include(m=>m.Category).Skip(skip ?? 0)
                                                               .Take(take).ToListAsync();

            return await query;
        }

        public IQueryable<Product> GetAllWithExpression(Expression<Func<Product, bool>> predicate)
        {
            predicate ??= x => true;
            return _context.Products.Include(m => m.Category).Where(predicate);
        }

        public IQueryable<Product> GetAllWithIncludes()
        {
            return _context.Products.Include(m => m.Category);
        }

        public async Task<Product> GetByIdImagesWithIncludesAsync(int id)
        {
            return await _context.Products.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);

        }

        public async Task<Product> GetByIdWithIncludesAsync(int id)
        {
            return await _context.Products.Include(m => m.Category).FirstOrDefaultAsync(m => m.Id == id);

        }

        public IEnumerable<Product> GetComparisonProducts(int categoryId, int selectedProductId, int count = 3)
        {
            var selectedProduct = _context.Products
                       .Include(p => p.Category)
                .FirstOrDefault(p => p.Id == selectedProductId);

            if (selectedProduct == null)
            {
                throw new KeyNotFoundException($"Product with ID {selectedProductId} not found!");
            }

            var randomProducts = _context.Products
                .Include(p => p.Category)
                .Where(p => p.CategoryId == categoryId && p.Id != selectedProductId)
                .OrderBy(r => Guid.NewGuid())
                .Take(count - 1)
                .ToList();

            randomProducts.Insert(0, selectedProduct);

            return randomProducts;
        }

        public async Task<decimal> GetMaxPriceAsync()
        {
            var products = await _context.Products.ToListAsync();
            return products.Any() ? products.Max(p => p.Price) : 0;
        }

        public async Task<int> GetProductsCount()
        {
            return await _context.Products.CountAsync();
        }

        public Task<Product> GetProductWithColorsAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Product>> SortedProductsAsync(string sortType)
        {
            var query = _context.Products.Include(p => p.ProductImages)
                                        .AsQueryable();

            switch (sortType)
            {
                case "A-Z":
                    query = query.OrderBy(p => p.Name);
                    break;
                case "Z-A":
                    query = query.OrderByDescending(p => p.Name);
                    break;
                case "Latest":
                    query = query.OrderByDescending(p => p.CreatedAt);
                    break;
                case "PriceLowToHigh":
                    query = query.OrderBy(p => p.Price);
                    break;
                case "PriceHighToLow":
                    query = query.OrderByDescending(p => p.Price);
                    break;
                default:
                    query = query.OrderBy(p => p.Name);
                    break;
            }

            return await query.ToListAsync();
        }

        public async Task<ProductImage> GetByIdAsync(int id)
        {
            return await _context.ProductImages.FindAsync(id);
        }
    }
}
