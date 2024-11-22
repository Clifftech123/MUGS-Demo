

using MUGS2024dEMO.ApiService.Domain.Contracts;
using MUGS2024dEMO.ApiService.Domain.Entities;

namespace MUGS2024dEMO.ApiService.Services
{
    public class ProductService : IProductService
    {
     
        public Task<bool> AddProductAsync(CreateProductDto createProductDto)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteProductAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductDetailByIdAsync(int productId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> ProductListAsync(int pageNumber, int pageSize, string? searchTerm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            throw new NotImplementedException();
        }
    }
}