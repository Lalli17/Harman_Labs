using HarmancoolProductsService.Models.Entities;

namespace HarmancoolProductsService.Models.Domain
{
    public interface ICoolProductsService
    {
        Task<List<Product>> GetProductsAsync();
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetProductByCountryAsync(String country);
        Task EditProduct(Product product);
        Task SoftDeleteProduct(int id);
        Task SaveProductAsync(Product product);

    }
}
//implement in the data layer