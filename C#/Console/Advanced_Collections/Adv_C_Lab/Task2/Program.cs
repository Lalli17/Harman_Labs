namespace Task2
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

            // Step 2: Convert List<Person> to Dictionary<int, Person>
            Dictionary<int, Person> personDictionary = new Dictionary<int, Person>();
            int id = 1;
            foreach (var person in people)
            {
                personDictionary.Add(id++, person); // Assign unique ID starting from 1
            }

            // Display Dictionary contents
            Console.WriteLine("Dictionary Contents:");
            foreach (var entry in personDictionary)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value.Name}, Age: {entry.Value.Age}");
            }

            // Step 3: Convert Dictionary back to List<Person> filtering Age > 25
            List<Person> filteredList = personDictionary
                                        .Where(kvp => kvp.Value.Age > 25)
                                        .Select(kvp => kvp.Value)
                                        .ToList();

            // Display filtered list
            Console.WriteLine("\nFiltered List (Age > 25):");
            foreach (var person in filteredList)
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
}
