using ComplexCRUD_Student.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCRUD_Student.Data
{
    public class StudentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanAdvanceStudentDb;Trusted_Connection=True");

        }
        public DbSet<Student> Students { get; set; }

    }
}
