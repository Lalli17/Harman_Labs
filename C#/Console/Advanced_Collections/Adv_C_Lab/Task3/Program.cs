using System;
using System.Text.Json;

namespace Task3
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

            // Deep Copy test
            var copiedPeople = people.DeepCopy();

            // Modify original
            people[0].Name = "ALICE_MODIFIED";

            Console.WriteLine("Original List:");
            foreach (var p in people)
                Console.WriteLine($"{p.Name}, {p.Age}");

            Console.WriteLine("\nCopied List (DeepCopy):");
            foreach (var p in copiedPeople)
                Console.WriteLine($"{p.Name}, {p.Age}");

            // Shuffle test
            copiedPeople.Shuffle();
            Console.WriteLine("\nShuffled Copied List:");
            foreach (var p in copiedPeople)
                Console.WriteLine($"{p.Name}, {p.Age}");
        }
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { } // parameterless constructor

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    public static class CollectionExtensions
    {
        // Shuffle extension method using Fisher–Yates algorithm
        public static void Shuffle<T>(this IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                // Swap
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // DeepCopy extension method using JSON serialization
        public static List<T> DeepCopy<T>(this List<T> list) where T : class, new()
        {
            // Using System.Text.Json for deep cloning
            var json = JsonSerializer.Serialize(list);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
