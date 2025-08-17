namespace Task3_Part3
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

                // Validate numerator
                if (!int.TryParse(input1, out int numerator))
                {
                    throw new InvalidInputException(input1, "Numerator is not a valid integer.");
                }

                // Validate denominator
                if (!int.TryParse(input2, out int denominator))
                {
                    throw new InvalidInputException(input2, "Denominator is not a valid integer.");
                }

                // Perform division
                int result = numerator / denominator;
                Console.WriteLine($"Result: {result}");
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("InvalidInputException Caught!");
                Console.WriteLine($"Value: {ex.InputValue}");
                Console.WriteLine($"Reason: {ex.ReasonForInvalidity}");
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
        public string InputValue { get; }
        public string ReasonForInvalidity { get; }

        public InvalidInputException(string inputValue, string reason)
            : base($"Invalid input: {inputValue} — Reason: {reason}")
        {
            InputValue = inputValue;
            ReasonForInvalidity = reason;
        }
    }
}
