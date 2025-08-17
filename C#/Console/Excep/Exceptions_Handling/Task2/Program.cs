namespace Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a number to divide 100 by:");

            try
            {
                // Attempt to parse input to integer (can throw FormatException)
                string input = Console.ReadLine();
                int number = int.Parse(input);  // May throw FormatException

                try
                {
                    // Division operation (can throw DivideByZeroException)
                    int result = 100 / number;
                    Console.WriteLine($"Result of division: {result}");
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("Error: Cannot divide by zero.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Invalid input. Please enter a valid integer.");
            }
            finally
            {
                Console.WriteLine("Execution of nested try-catch block is complete.");
            }
        }
    }
}
