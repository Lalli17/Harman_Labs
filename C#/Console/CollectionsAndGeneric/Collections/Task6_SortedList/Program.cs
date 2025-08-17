namespace Task6_SortedList
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SortedList<string, ClsPerson> persons = new SortedList<string, ClsPerson>();

            // Step 2: Add initial person objects
            persons.Add("John", new ClsPerson("John", 16, "Chennai"));
            persons.Add("Smita", new ClsPerson("Smita", 22, "Delhi"));
            persons.Add("Vincet", new ClsPerson("Vincet", 25, "Bangalore"));
            persons.Add("Jyothi", new ClsPerson("Jyothi", 10, "Bangalore"));

            // Step 3: Try adding duplicate Name
            try
            {
                persons.Add("Jyothi", new ClsPerson("Jyothi", 30, "Mumbai"));
            }
            catch (ArgumentException)
            {
                Console.WriteLine("Cannot add duplicate key: 'Jyothi' already exists in SortedList.");
            }

            // Step 4: Try adding another person with same Age = 10
            try
            {
                persons.Add("Ajay", new ClsPerson("Ajay", 10, "Pune"));
            }
            catch (Exception e)
            {
                Console.WriteLine("Unexpected error: " + e.Message);
            }

            // Step 5: Iterate and print Name, Age, CanVote
            Console.WriteLine("\nSortedList - Persons Info:");
            foreach (KeyValuePair<string, ClsPerson> entry in persons)
            {
                Console.WriteLine($"Name: {entry.Value.Name}, Age: {entry.Value.Age}, CanVote: {entry.Value.CanVote()}");
            }
        }
    }
    class ClsPerson
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public string PlaceOfBirth { get; set; }

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
