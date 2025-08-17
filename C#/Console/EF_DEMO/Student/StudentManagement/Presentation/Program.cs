using StudentManagement.Data;
using StudentManagement.Entities;

namespace StudentManagement.Presentation2

{
    internal class Program
    {
        static void Main(string[] args)
        {
            create();
            read();
            update();
            delete();

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
