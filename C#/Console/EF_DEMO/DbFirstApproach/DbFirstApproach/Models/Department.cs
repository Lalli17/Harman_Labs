using System;
using System.Collections.Generic;

namespace DbFirstApproach.Models;

public partial class Department
{
    public int DepartmentId { get; set; }

    public string? Name { get; set; }

    public decimal? Budget { get; set; }

    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
