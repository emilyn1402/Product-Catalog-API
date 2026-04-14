using ProductCatalogAPI.DTOs;
using ProductCatalogAPI.Model;

namespace ProductCatalogAPI.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(CreateProductDTO dto);
        Task<Product> UpdateAsync(int id, UpdateProductDTO dto);
        Task<bool> DeleteAsync(int id);
        Task<List<Product>> SearchAsync(string search);
    }
}
