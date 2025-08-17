using DbFirstApproach.Models;
using Microsoft.EntityFrameworkCore;

namespace DbFirstApproach
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Scaffold-DbContext "Data Source=(localdb)\mssqllocaldb;Initial Catalog=UniversityDb;Integrated Security=True; " Microsoft.EntityFrameworkCore.SqlServer -o Models

            //add
            //using (var context = new UniversityDbContext())
            //{
            //    var students = context.Students
            //    .Include(s => s.Enrollments)
            //    .ThenInclude(e => e.Course)
            //    .ToList();
            //    foreach (var student in students)
            //    {
            //        Console.WriteLine($"{student.FirstName} {student.LastName}");
            //        foreach (var enrollment in student.Enrollments)
            //        {
            //            Console.WriteLine($" Enrolled in: { enrollment.Course.Title}, Grade: { enrollment.Grade}");
            //        }
            //    }
            //}
            //new student
            using (var context = new UniversityDbContext())
            {
                var newStudent = new Student
                {
                    FirstName = "Jane",
                    LastName = "Smith",
                    EnrollmentDate = DateTime.Now,
                    Email = "jane.smith@example.com"
                };
                context.Students.Add(newStudent);
                context.SaveChanges();
                var enrollment = new Enrollment
                {
                    StudentId = newStudent.StudentId,
                    CourseId = 1, // Assuming course ID 1 exists
                    Grade = 90
                };
                context.Enrollments.Add(enrollment);
                context.SaveChanges();
            }
            //deleting
            using (var context = new UniversityDbContext())
            {
                var student = context.Students
                .Include(s => s.Enrollments)
                .FirstOrDefault(s => s.StudentId == 1);
                if (student != null)
                {
                    context.Students.Remove(student);
                    context.SaveChanges();
                }
            }


        }
    }
}
