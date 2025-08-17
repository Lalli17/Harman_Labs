using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentEnrollment.Entities
{
    public class StudentEnroll
    {
        [Key]
        public int EnrollmentId { get; set; }

        [Required(ErrorMessage = "StudentId is required.")]
        public int StudentId { get; set; }

        [Required(ErrorMessage = "CourseId is required.")]
        public int CourseId { get; set; }

        [Required(ErrorMessage = "EnrollmentDate is required.")]
        public DateTime? EnrollmentDate { get; set; }

        [Range(0, 100, ErrorMessage = "Grade must be between 0 and 100.")]
        public decimal? Grade { get; set; }

        //public Student Student { get; set; }
        //public Course Course { get; set; }
    }

    //public class Course
    //{
    //    public int CourseId { get; set; }

    //    public string CourseName { get; set; }
    //}

    //public class Student
    //{
    //    public int StudentId { get; set; }
    //    public string StudentName { get; set; }

    //}
}

