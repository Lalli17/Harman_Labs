using StudentEnrollment.Data;
using StudentEnrollment.Entities;
using System.ComponentModel.DataAnnotations;

namespace StudentEnrollment.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using var context = new SchoolContext();

            // CREATE
            // create(context);

            // READ
            //  read(context);

            // UPDATE
            //update(context);

            // DELETE
            // delete(context);

            //Grade>80%
            // higherGrade(context);

            //sort via enrollmentdate

             Sort(context);

            //data annotaions and validation
            // Validation(context);

        }

        private static SchoolContext Sort(SchoolContext context)
        {
            var contexts = new SchoolContext();

            var sortedEnrollments = context.studentEnrollments
                .OrderByDescending(e => e.EnrollmentDate)
                .ToList();

            Console.WriteLine("\n-----------------Enrollments sorted by EnrollmentDate (descending):---------------\n");
            foreach (var enrollment in sortedEnrollments)
            {
                Console.WriteLine($"ID: {enrollment.EnrollmentId}, Student: {enrollment.StudentId}, Date: {enrollment.EnrollmentDate}, Grade: {enrollment.Grade}");
            }

            return contexts;
        }

        private static void create(SchoolContext context)
        {
            var enrollment = new StudentEnroll
            {
                StudentId = 6,
                CourseId = 103,
                EnrollmentDate = DateTime.Now,
                Grade = 90m
            };
            context.studentEnrollments.Add(enrollment);
            context.SaveChanges();
            Console.WriteLine("\n---Enrollment created.---\n");
        }

        private static void Validation(SchoolContext context)
        {
            var invalidEnrollment = new StudentEnroll
            {
                StudentId = 1,
                CourseId = 101,
                EnrollmentDate = null,       // ❌ Missing date
                Grade = 120.5m               // ❌ Invalid grade
            };

            // Perform validation
            var contexts = new ValidationContext(invalidEnrollment, null, null);
            var results = new List<ValidationResult>();
            bool isValid = Validator.TryValidateObject(invalidEnrollment, contexts, results, true);

            // Check validation results
            if (isValid)
            {
                using var dbContext = new SchoolContext();
                dbContext.studentEnrollments.Add(invalidEnrollment);
                dbContext.SaveChanges();
                Console.WriteLine("\n----------Enrollment added successfully.------------\n");
            }
            else
            {
                Console.WriteLine("\n-----------Validation Errors:----------\n");
                foreach (var validationResult in results)
                {
                    Console.WriteLine($"- {validationResult.ErrorMessage}");
                }
            }
        }

        private static void higherGrade(SchoolContext context)
        {
            var highGrades = context.studentEnrollments
                            .Where(e => e.Grade > 80)
                            .OrderByDescending(e => e.EnrollmentDate)
                            .ToList();

            Console.WriteLine("\n-----------------Enrollments with Grade > 80:-----------------------\n");
            highGrades.ForEach(e => Console.WriteLine($"{e.EnrollmentId}|{e.StudentId} |{e.CourseId} | {e.Grade} | {e.EnrollmentDate}"));
        }

        private static void delete(SchoolContext context)
        {
            var existing = context.studentEnrollments.FirstOrDefault();
            if (existing != null)
            {
                context.studentEnrollments.Remove(existing);
                context.SaveChanges();
                Console.WriteLine("Enrollment deleted.");
            }
        }

        private static void update(SchoolContext context)
        {
            var existing = context.studentEnrollments.FirstOrDefault();
            if (existing != null)
            {
                existing.Grade = 90.0m;
                context.SaveChanges();
                Console.WriteLine("\nUpdated Grade.");
            }
        }

        private static void read(SchoolContext context)
        {
            var enrollments = context.studentEnrollments.ToList();
            Console.WriteLine("\n--------------All Enrollments:-----------");
            enrollments.ForEach(e => Console.WriteLine($"{e.EnrollmentId} | {e.StudentId} | {e.CourseId} | {e.EnrollmentDate} | {e.Grade}"));
        }
    }
}
