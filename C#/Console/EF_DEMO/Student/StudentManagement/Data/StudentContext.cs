using Microsoft.EntityFrameworkCore;
using StudentManagement.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Data
{
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanStudentDb;Trusted_Connection=True");
        }
    }
}
;