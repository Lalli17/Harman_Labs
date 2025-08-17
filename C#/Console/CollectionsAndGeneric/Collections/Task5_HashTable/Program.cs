using System.Collections;

namespace Task5_HashTable
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creating person objects
            ClsPerson p1 = new ClsPerson("John", 16, "Chennai");
            ClsPerson p2 = new ClsPerson("Smita", 22, "Delhi");
            ClsPerson p3 = new ClsPerson("Vincet", 25, "Bangalore");
            ClsPerson p4 = new ClsPerson("Jyothi", 10, "Bangalore");

            // Step: Add to hashtable with key as Name
            Hashtable persons = new Hashtable();

            persons.Add(p1.Name, p1);
            persons.Add(p2.Name, p2);
            persons.Add(p3.Name, p3);
            persons.Add(p4.Name, p4);

            // Try adding a duplicate name
            try
            {
                ClsPerson duplicateName = new ClsPerson("Jyothi", 30, "Mumbai");
                persons.Add(duplicateName.Name, duplicateName);
            }
            catch (ArgumentException)
            {
                Console.WriteLine("\nCannot add duplicate key: 'Jyothi' already exists in the hashtable.");
            }

            // Try adding person with same age (allowed since key is Name)
            try
            {
                ClsPerson sameAge = new ClsPerson("Ajay", 10, "Pune");
                persons.Add(sameAge.Name, sameAge);  // No error, name is unique
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

            // Traverse and print name and voting eligibility
            Console.WriteLine("\nName and Voting Eligibility:");
            foreach (DictionaryEntry entry in persons)
            {
                ClsPerson person = (ClsPerson)entry.Value;
                Console.WriteLine($"{person.Name} can vote: {person.CanVote()}");
            }
        }

        class ClsPerson
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string PlaceOfBirth { get; set; }
            //default values
            public ClsPerson()
            {
                Name = "Unknown";
                Age = 0;
                PlaceOfBirth = "Unknown";
            }

            public ClsPerson(string name, int age, string placeOfBirth)
            {
                Name = name;
                Age = age;
                PlaceOfBirth = placeOfBirth;
            }

   
            public bool CanVote()
            {
                return Age >= 18;
            }
        }
    }
}
