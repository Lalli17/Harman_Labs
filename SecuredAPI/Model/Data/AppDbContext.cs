using Microsoft.EntityFrameworkCore;
using SecuredAPI.Model.Entities;

namespace SecuredAPI.Model.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            // database config with DI
        }

        // map entites with tables

        public DbSet<User> AppUsers { get; set; }
    }
}
