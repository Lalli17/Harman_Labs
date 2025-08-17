using Microsoft.EntityFrameworkCore;
using SecurApi.Model.Entities;

namespace SecurApi.Model.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
            //databse config with DI dependency injection
        }

        //map entities with tables

        public DbSet<User> AppUsers { get; set; }
    }
}
