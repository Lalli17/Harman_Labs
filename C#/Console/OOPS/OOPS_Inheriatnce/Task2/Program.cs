namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person[] people = new Person[10];
            people[0] = new Student { Name = "Lalitha", Percentage = 99 };
            people[1] = new Student {Name="Ram",Percentage = 90};
            people[2] = new Student { Name = "Advik", Percentage = 18 };
            people[3] = new Student { Name = "Carla", Percentage = 52 };
            people[4] = new Student { Name = "David", Percentage = 09 };
           // people[5] = new Professor { Name = "Edmund", Bookspublished = 2 };

            foreach (Person person in people)
            {
                if (person.IsOutStanding())
                {
                    if (person is Student student)
                    {
                        student.print();
                    }
                    else if (person is Professor professor)
                    {
                        professor.print();
                    }

                }
            }


        }
    }

    class Person
    {
        public string Name { get; set; }
        public virtual bool IsOutStanding()
        { return false; }
    }

    class Professor : Person
    {
        public int Bookspublished { get; set; }
        public override bool IsOutStanding() 
        {
            return Bookspublished>4; 
        }
        public void print()
        {
            Console.WriteLine($"Professor name {Name}, Books published {Bookspublished}");
        }
    }

    class Student : Person
    {
        public double Percentage { get; set; }
        public override bool IsOutStanding()
        { 
            return Percentage > 85;
        }
        public void print()
        {
            Console.WriteLine($"Student name {Name},Percentage {Percentage}");
        }
    }
}
