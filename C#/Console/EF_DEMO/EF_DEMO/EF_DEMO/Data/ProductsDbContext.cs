using EF_DEMO.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_DEMO.Data
{
    public class ProductsDbContext : DbContext
    {
        //1.confiure database
        //dbcontext has virtual method so child class can ovveride

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanProductsDb;Trusted_Connection=True;");
            optionsBuilder.LogTo(Console.WriteLine,LogLevel.Information);
        
        
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Person>().UseTptMappingStrategy();
          modelBuilder.Entity<Person>().UseTpcMappingStrategy();
        }


        public DbSet<Product> Products { get; set; } //dbsets acts as a collection framework and the table name is products incase u have more then add more dbset
        public DbSet<Category> Categories { get; set; }//categories is just the property and not the actual convention

       public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; }

        //2.Map Entities with Tables
    }
}
