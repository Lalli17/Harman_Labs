using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public DateTime? EnrollmentDate { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
