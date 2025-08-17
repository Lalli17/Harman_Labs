using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Management_System.Entities
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string Name { get; set; }

        public OfficeAssignment OfficeAssignment { get; set; }
    }

    public class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public int OfficeAssignmentId { get; set; }
        public string Location { get; set; }

        public Instructor Instructor { get; set; }
    }

    public class Department
    {
        public int DepartmentId { get; set; }
        public string Name { get; set; }

        public ICollection<Course> Courses { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string Title { get; set; }

        public int DepartmentId { get; set; }
        public Department Department { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Student
    {
        public int StudentId { get; set; }
        public string FullName { get; set; }

        public ICollection<Enrollment> Enrollments { get; set; }
    }

    public class Enrollment
    {
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }

        public double Grade { get; set; }
    }


    public class OnlineCourse : Course
    {
       // public string Title { get; set;}
        public string Platform { get; set; }

        public Department Department { get; set; }
    }


    public class OnSiteCourse : Course
    {
       // public string Title { get; set;}
        public string RoomNumber { get; set; }
        public string Schedule { get; set; }

        public Department Department{ get; set; }
    }


}
