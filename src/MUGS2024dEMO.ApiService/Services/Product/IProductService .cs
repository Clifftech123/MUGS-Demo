using MUGS2024dEMO.ApiService.Domain.Contracts;
using MUGS2024dEMO.ApiService.Domain.Entities;

namespace MUGS2024dEMO.ApiService.Services
{
    public interface IProductService
    {
        Task<List<Product>> ProductListAsync(int offset = 1, int limit = 10, string? searchQuery = null);
        Task<Product> GetProductDetailByIdAsync(int productId);
        Task<bool> AddProductAsync(CreateProductDto createProductDto);
        Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<bool> DeleteProductAsync(int productId);
    }
}
