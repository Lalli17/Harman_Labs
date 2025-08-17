namespace Task3_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.Write("Enter numerator: ");
                string input1 = Console.ReadLine();

                Console.Write("Enter denominator: ");
                string input2 = Console.ReadLine();

                // Validate inputs
                if (!int.TryParse(input1, out int numerator))
                {
                    throw new InvalidInputException("Numerator is not a valid number.");
                }

                if (!int.TryParse(input2, out int denominator))
                {
                    throw new InvalidInputException("Denominator is not a valid number.");
                }

                // Division logic
                Double result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine($"Input Error: {ex.Message}");
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Math Error: Cannot divide by zero.");
            }
            finally
            {
                Console.WriteLine("Program execution completed.");
            }
        }
    }

    public class InvalidInputException : ApplicationException
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
