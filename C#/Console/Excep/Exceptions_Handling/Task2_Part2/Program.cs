namespace Task2_Part2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PerformCalculation();
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine("Caught an ArithmeticException in Main.");
                Console.WriteLine($"Error message: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("Arithmetic exception propagation example complete.");
            }
        }

        static void PerformCalculation()
        {
            DivideNumbers(10, 0);  // This will throw ArithmeticException
        }

        static void DivideNumbers(int numerator, int denominator)
        {
            if (denominator == 0)
            {
                throw new ArithmeticException("Attempted to divide by zero.");
            }

            int result = numerator / denominator;
            Console.WriteLine($"Result: {result}");
        }
    }
}
