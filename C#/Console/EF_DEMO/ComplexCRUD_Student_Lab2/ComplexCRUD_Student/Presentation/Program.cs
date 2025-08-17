using ComplexCRUD_Student.Data;
using ComplexCRUD_Student.Entities;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ComplexCRUD_Student.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // create();
            //read();
            // update();
            //delete();

            // ageCriteria();
            // sortAndPagination();

            //  Validation();

            //BulkAddition();

            //BulkUpdate();


            using (var context = new StudentContext())
            {
                var student = context.Students.FirstOrDefault(s => s.Name ==
                "Alice Smith");
                if (student != null)
                {
                    student.Age = 23; // Assume this is an updated value
                    try
                    {
                        context.SaveChanges();
                        Console.WriteLine("Student record updated.");
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.WriteLine("Concurrency conflict detected. Please refresh and try again.");
                        }
}
                }

            }

        private static void BulkUpdate()
        {
            using (var context = new StudentContext())
            {
                var students = context.Students.ToList();
                foreach (var student in students)
                {
                    student.Email = student.Email.Replace("@example.com",
                    "@newdomain.com");
                }
                context.SaveChanges();
                Console.WriteLine("Bulk update completed.");
            }
        }

        private static void BulkAddition()
        {
            using (var context = new StudentContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var students = new List<Student>
                        {
                            new Student { Name = "Alice Smith", Age = 22, Email ="alice.smith@example.com" },
                            new Student { Name = "Bob Johnson", Age = 25, Email ="bob.johnson@example.com" },
                            new Student { Name = "Charlie Brown", Age = 21, Email= "charlie.brown@example.com" }
                           };
                        context.Students.AddRange(students);
                        context.SaveChanges();
                        transaction.Commit();
                        Console.WriteLine("Students added successfully.");
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        Console.WriteLine($"Transaction failed: {ex.Message}");
                    }
                }
            }
        }

        private static void Validation()
        {
            var student = new Student
            {
                Name = "John Doe",
                Age = 17, // Invalid age to trigger validation error
                Email = "john.doeexample.com"// invalid email
            };
            var context = new ValidationContext(student, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(student, context, results,
            true);
            if (isValid)
            {
                using (var dbContext = new StudentContext())
                {
                    dbContext.Students.Add(student);
                    dbContext.SaveChanges();
                    Console.WriteLine("Student record added.");
                }
            }
            else
            {
                foreach (var validationResult in results)
                {
                    Console.WriteLine(validationResult.ErrorMessage);
                }
            }
        }

        private static void sortAndPagination()
        {
            using (var context = new StudentContext())
            {
                Console.WriteLine("\n---------------2.Sorting by name and Pagination - 5 records each -----------------\n");
                int pageNumber = 1;
                int pageSize = 10;
                var students = context.Students
                    .OrderBy(s => s.Name)
                    .Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name},Age: {student.Age}, Email: {student.Email}");
                }
            }
        }

        private static void ageCriteria()
        {
            //age criteria > 20
            using (var context = new StudentContext())
            {
                Console.WriteLine("\n---------------1. Criteria Age >20-----------------\n");
                var students = context.Students
                .Where(s => s.Age > 20)
                .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine($"ID: {student.Id}, Name: {student.Name},Age: {student.Age}, Email: {student.Email}");
                }
            }
        }

        private static void delete()
            {
                using (var context = new StudentContext())
                {
                    var student = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                    if (student != null)
                    {
                        context.Students.Remove(student);
                        context.SaveChanges();
                        Console.WriteLine("Student record deleted.");
                    }
                }
            }

            private static void update()
            {
                using (var context = new StudentContext())
                {
                    var student = context.Students.FirstOrDefault(s => s.Name == "John Doe");
                    if (student != null)
                    {
                        student.Age = 21;
                        context.SaveChanges();
                        Console.WriteLine("Student record updated.");
                    }
                }
            }

            private static void read()
            {
                using (var context = new StudentContext())
                {
                    var students = context.Students.ToList();

                    foreach (var student in students)
                    {
                        Console.WriteLine($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}, Email: {student.Email}");
                    }
                }
            }

            private static void create()
            {
                using (var context = new StudentContext())
                {
                    var student = new Student
                    {
                        Name = "John Doe",
                        Age = 22,
                        Email = "john.doe@gmail.com"
                    };
                    context.Students.Add(student);
                    context.SaveChanges();

                }
                Console.WriteLine("Student record added");
            }
        }
    }

