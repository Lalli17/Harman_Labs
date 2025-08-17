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
        public int OfficeAssignmentId { get; set; }
        public string location { get; set; }

        public Instructor Instructor { get; set; }
    }

}
