using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Data
{
    internal class UniversityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanUniversityDb;Trusted_Connection=True;");
        }
       // Data Source = (localdb)\mssqllocaldb;Initial Catalog = HarmanUniversityDb; Integrated Security = True

        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<OfficeAssignment> OfficeAssignments { get; set; }

    }
}
