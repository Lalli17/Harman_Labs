using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Data
{
    public class UniversityDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=HarmanUniversityDb;Trusted_Connection=True;");
        }


            public DbSet<Instructor> Instructors { get; set; }
            public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
            public DbSet<Department> Departments { get; set; }
            public DbSet<Course> Courses { get; set; }
            public DbSet<Student> Students { get; set; }
            public DbSet<Enrollment> Enrollments { get; set; }


            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {


                 //1.Table Per Hierarchy(default - optional)
                 // modelBuilder.Entity<Course>().UseTphMappingStrategy();

                // ✅ 2. Table Per Type
                 // modelBuilder.Entity<Course>().UseTptMappingStrategy();

                // ✅ 3. Table Per Concrete Type (EF Core 7+)
                 modelBuilder.Entity<Course>().UseTpcMappingStrategy();

            // Optional: Rename tables for clarity
            modelBuilder.Entity<OnlineCourse>().ToTable("OnlineCourses");
            modelBuilder.Entity<OnSiteCourse>().ToTable("OnSiteCourses");

            // One-to-One: Instructor ↔ OfficeAssignment
            modelBuilder.Entity<Instructor>()
                    .HasOne(i => i.OfficeAssignment)
                    .WithOne(o => o.Instructor)
                    .HasForeignKey<OfficeAssignment>(o => o.InstructorId);

                // One-to-Many: Department → Courses
                modelBuilder.Entity<Department>()
                    .HasMany(d => d.Courses)
                    .WithOne(c => c.Department)
                    .OnDelete(DeleteBehavior.Cascade);

                // Many-to-Many: Student ↔ Course via Enrollment
                modelBuilder.Entity<Enrollment>()
                    .HasKey(e => new { e.CourseId, e.StudentId });

                modelBuilder.Entity<Enrollment>()
                    .HasOne(e => e.Course)
                    .WithMany(c => c.Enrollments)
                    .HasForeignKey(e => e.CourseId);

                modelBuilder.Entity<Enrollment>()
                    .HasOne(e => e.Student)
                    .WithMany(s => s.Enrollments)
                    .HasForeignKey(e => e.StudentId);
            }
    }
}
