using Authentication_Lab_ASP.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication_Lab_ASP.Data
{
    public class AppDbContext : DbContext

    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
    }
}
