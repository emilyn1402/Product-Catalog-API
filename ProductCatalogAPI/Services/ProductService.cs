using Microsoft.EntityFrameworkCore;
using ProductCatalogAPI.Data;
using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Model;

namespace ProductCatalogAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _context.Products.ToListAsync(); 
        }

        public async Task<Product> GetByIdAsync(int id) 
        {
            return await _context.Products.FindAsync(id);
        }
        public async Task<Product> CreateAsync(CreateProductDTO dto) 
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock
            };

            _context.Products.Add(product);
            await _context.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(int id, UpdateProductDTO dto)
        {
            var product = _context.Products.Find(id);

            if (product == null) return null;

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await _context.SaveChangesAsync();

            return product;
            
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null) return false;

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<List<Product>> SearchAsync(string keyword)
        {
            var product = _context.Products
                .Where(p => p.Name.Contains(keyword))
                .ToListAsync();

            if (product == null) return null;

            return await product;
        }
    }
}
