using University_Course_Management_System.Data;
using University_Course_Management_System.Entities;

namespace University_Course_Management_System.Presentation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (UniversityDbContext db = new UniversityDbContext())
            {
                var instructor = new Instructor { Name = "Dr. Smith" };
                var office = new OfficeAssignment { Instructor = instructor, Location = "B-102" };

                var dept = new Department { Name = "Computer Science" };
                var course1 = new Course { Title = "C#", Department = dept };
                var course2 = new Course { Title = "SQL", Department = dept };

                var student1 = new Student { FullName = "Alice" };
                var student2 = new Student { FullName = "Bob" };

                var enrollment1 = new Enrollment { Course = course1, Student = student1, Grade = 8.5 };
                var enrollment2 = new Enrollment { Course = course1, Student = student2, Grade = 9.0 };
                var enrollment3 = new Enrollment { Course = course2, Student = student1, Grade = 7.0 };

                var onlineCourse = new OnlineCourse
                {
                   // Title = "AI with Python",
                    Platform = "Udemy",
                    Department = dept
                };

                var onsiteCourse = new OnSiteCourse
                {
                    //Title = "Data Structures",
                    RoomNumber = "Room 203",
                    Schedule = "MWF 10AM",
                    Department = dept
                };

                db.AddRange(instructor, office, dept, course1, course2, student1, student2, enrollment1, enrollment2, enrollment3,onlineCourse,onsiteCourse);
                db.SaveChanges();


            }
        }
    }
}
