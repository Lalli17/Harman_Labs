namespace FileIO_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
          
                string filePath = "TextFile1.txt";

                if (!File.Exists(filePath))
                {
                    Console.WriteLine("File not found: " + filePath);
                    return;
                }

                string rawContent = File.ReadAllText(filePath);

                // Remove quotes and split by commas
                List<string> names = rawContent
                    .Replace("\"", "")
                    .Split(',')
                    .ToList();

                // Sort names alphabetically
                names.Sort();

                long totalScore = 0;

                for (int i = 0; i < names.Count; i++)
                {
                    string name = names[i];
                    int nameValue = GetAlphabeticalValue(name);
                    int position = i + 1;
                    totalScore += nameValue * position;
                }

                Console.WriteLine("Total of all name scores: " + totalScore);
            }

            static int GetAlphabeticalValue(string name)
            {
                int value = 0;
                foreach (char c in name.ToUpper())
                {
                    value += (c - 'A' + 1); // A=1, B=2, ..., Z=26
                }
                return value;
            }
        }
    }
