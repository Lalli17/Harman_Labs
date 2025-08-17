namespace Task2_Dict
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> people = CreateAndPopulateDictionary();
            foreach (var entry in people)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
            }
            Console.WriteLine();

            // Step 2: Find name by ID
            Console.WriteLine("Enter an ID to search for the name:");
            int searchId;
            if (int.TryParse(Console.ReadLine(), out searchId))
            {
                FindNameById(people, searchId);
            }

            // Step 3: Update name for a given ID
            Console.WriteLine("\nEnter the ID you want to update:");
            int updateId;
            if (int.TryParse(Console.ReadLine(), out updateId))
            {
                Console.WriteLine("Enter the new name:");
                string newName = Console.ReadLine();
                UpdateNameById(people, updateId, newName);
            }

            // Display final dictionary
            Console.WriteLine("\nFinal Dictionary Contents:");
            foreach (var entry in people)
            {
                Console.WriteLine($"ID: {entry.Key}, Name: {entry.Value}");
            }
        }

        // Method 1: Create and populate dictionary
        static Dictionary<int, string> CreateAndPopulateDictionary()
        {
            return new Dictionary<int, string>
        {
            { 101, "Alice" },
            { 102, "Bob" },
            { 103, "Charlie" },
            { 104, "Diana" },
            { 105, "Ethan" }
        };
        }

        // Method 2: Find name by ID
        static void FindNameById(Dictionary<int, string> dict, int id)
        {
            if (dict.ContainsKey(id))
            {
                Console.WriteLine($"Name for ID {id}: {dict[id]}");
            }
            else
            {
                Console.WriteLine($"ID {id} not found in the dictionary.");
            }
        }

        // Method 3: Update name by ID
        static void UpdateNameById(Dictionary<int, string> dict, int id, string newName)
        {
            if (dict.ContainsKey(id))
            {
                dict[id] = newName;
                Console.WriteLine($"Name for ID {id} updated to: {newName}");
            }
            else
            {
                Console.WriteLine($"Cannot update. ID {id} not found in the dictionary.");
            }
        }
    }
}
