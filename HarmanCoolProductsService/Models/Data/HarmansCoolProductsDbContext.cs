using HarmanCoolProductsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HarmanCoolProductsService.Models.Data
{
    public class HarmansCoolProductsDbContext : DbContext
    {
        // configure DB

        // use ctor

        public HarmansCoolProductsDbContext(DbContextOptions options) : base(options)
        {

        }

        // override onconfig

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HarmansCoolProductsServiceDB2025;Integrated Security=True;Pooling=False;Encrypt=True;Trust Server Certificate=True");
        //}


        // Map Entities with Tables
        public DbSet<Product> Products { get; set; }
    }
}
