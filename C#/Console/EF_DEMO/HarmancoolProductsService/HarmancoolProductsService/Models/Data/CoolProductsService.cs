using HarmancoolProductsService.Models.Domain;
using HarmancoolProductsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HarmancoolProductsService.Models.Data
{
    public class CoolProductsService : ICoolProductsService
    {
      private HarmanCoolProductsDbContext db = null;

        public CoolProductsService(HarmanCoolProductsDbContext db)
        {
            this.db = db;
        }//dependency inversion


       

        public async Task<Product> GetProductByIdAsync(int id)
        {
            //return db.Products.Find(id);

            return await db.Products.Where(p => p.IsDeleted == false && p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            return await db.Products.Where(p=>p.Name == name && p.IsDeleted==false).FirstOrDefaultAsync();
            
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return db.Products.Where(p=>p.IsDeleted==false).ToList();
        }

        public async Task<List<Product>> GetProductByCountryAsync(string country)
        {
            return  db.Products.Where( p => p.Country == country && p.IsDeleted==false).ToList();
        }
        public async Task EditProductAsync(Product product)
        {
            db.Products.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.Products.Add(product);
            await db.SaveChangesAsync();
        }

        public async Task SoftDeleteProductAsync(int id)
        {
           var productToSoftDel=await GetProductByIdAsync(id);
            productToSoftDel.IsDeleted = true;
            db.SaveChanges();

        }

        public async void SaveProduct(Product product)
        {
            db.Products.Add(product);
            db.SaveChanges();
        }
    }
}
