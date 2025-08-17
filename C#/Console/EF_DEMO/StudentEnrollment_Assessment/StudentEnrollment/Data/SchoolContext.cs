using Microsoft.EntityFrameworkCore;
using StudentEnrollment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Data
{
    public class SchoolContext :DbContext
    {
        public DbSet<StudentEnroll> studentEnrollments {  get; set; }
        //public DbSet<Student> students { get; set; }
        //public DbSet<Course> courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanStudentEnrollmentDb;Trusted_Connection=True");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentEnroll>(entity =>
            {
                entity.HasKey(e => e.EnrollmentId);
                entity.Property(e => e.StudentId).IsRequired();
                entity.Property(e => e.CourseId).IsRequired();
                entity.Property(e => e.EnrollmentDate).IsRequired();
                entity.Property(e => e.Grade).HasPrecision(5, 2);
            });
        }

    }
}
