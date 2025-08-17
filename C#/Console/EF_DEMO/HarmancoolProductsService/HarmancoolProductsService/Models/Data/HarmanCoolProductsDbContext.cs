using HarmancoolProductsService.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace HarmancoolProductsService.Models.Data
{
    public class HarmanCoolProductsDbContext : DbContext
    {
        //configure db 2 ways 1- override and 2-constructor
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=HarmanCoolProductsDb;Integrated Security=True;Encrypt=True");
        //}

        public HarmanCoolProductsDbContext(DbContextOptions options) : base(options) 
        {

        }


        //map entities with tables
        public  DbSet<Product> Products { get; set; }

    }
}
