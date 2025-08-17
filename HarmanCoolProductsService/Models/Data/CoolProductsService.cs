using HarmanCoolProductsService.Models.Domain;
using HarmanCoolProductsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HarmanCoolProductsService.Models.Data
{
    public class CoolProductsService : ICoolProductsService
    {

        private HarmansCoolProductsDbContext db = null;

        public CoolProductsService(HarmansCoolProductsDbContext db)
        {
            this.db = db;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await db.Products.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await db.Products.Where(p => p.Name == name && p.IsDeleted == false).FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await db.Products.Where(p => p.IsDeleted == false).ToListAsync();
        }

        public async Task<List<Product>> GetProductsByCountryAsync(string country)
        {
            return await db.Products.Where(p => p.Country == country && p.IsDeleted == false).ToListAsync();
        }

        public async Task SaveProductAsync(Product product)
        {
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task SoftDeleteProductAsync(int id)
        {
            var productToSoftDel = await GetProductByIdAsync(id);
            productToSoftDel.IsDeleted = true;
            await db.SaveChangesAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            db.Products.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
