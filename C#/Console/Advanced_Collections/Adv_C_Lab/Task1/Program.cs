namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
        {
            new Person("Alice", 24),
            new Person("Bob", 30),
            new Person("Charlie", 18),
            new Person("Diana", 27),
            new Person("Ethan", 22)
        };

            // Step 4: Sort using custom comparer
            people.Sort(new AgeDescendingComparer());

            // Step 5: Display the sorted list
            Console.WriteLine("People sorted by Age (Descending):");
            foreach (var person in people)
            {
                Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
            }
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    // Step 2: Create custom comparer for sorting by Age (descending)
    class AgeDescendingComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            // Descending order: compare y to x
            return y.Age.CompareTo(x.Age);
        }
    }

}
