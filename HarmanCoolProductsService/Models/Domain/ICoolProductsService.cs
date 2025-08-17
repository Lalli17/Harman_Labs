using HarmanCoolProductsService.Models.Entities;

namespace HarmanCoolProductsService.Models.Domain
{
    public interface ICoolProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductByIdAsync(int id);
        Task<Product> GetProductByNameAsync(string name);
        Task<List<Product>> GetProductsByCountryAsync(string country);
        Task UpdateProductAsync(Product product);
        Task SoftDeleteProductAsync(int id);
        Task SaveProductAsync(Product product);
    }
}
