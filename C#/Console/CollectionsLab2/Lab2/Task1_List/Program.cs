namespace Task1_List
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> names = CreateAndPopulateList();

            // Step 2: Display original list
            Console.WriteLine("Original list of names:");
            DisplayListContents(names);

            // Step 3: Insert a name at a specified index
            Console.WriteLine("\nEnter a name to insert:");
            string newName = Console.ReadLine();

            Console.WriteLine("Enter the index to insert at (0 to " + names.Count + "):");
            int index;
            if (int.TryParse(Console.ReadLine(), out index))
            {
                InsertName(names, newName, index);
            }
            else
            {
                Console.WriteLine("Invalid index input.");
            }

            // Step 4: Display modified list
            Console.WriteLine("\nModified list of names:");
            DisplayListContents(names);
        }

        // Method 1: Create and populate list with 10 names
        static List<string> CreateAndPopulateList()
        {
            return new List<string>
        {
            "Alice",
            "Bob",
            "Charlie",
            "Diana",
            "Ethan",
            "Fiona",
        };
        }

        // Method 2: Display list contents
        static void DisplayListContents(List<string> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"[{i}] {list[i]}");
            }
        }

        // Method 3: Insert name at specified index
        static void InsertName(List<string> list, string name, int index)
        {
            if (index >= 0 && index <= list.Count)
            {
                list.Insert(index, name);
                Console.WriteLine($"\n'{name}' inserted at index {index}.");
            }
            else
            {
                Console.WriteLine("Index out of range.");
            }
        }
    }
}
