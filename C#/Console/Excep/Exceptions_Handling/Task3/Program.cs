namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Enter a number if -ve will get custom error");
                int num=int.Parse(Console.ReadLine());
                ValidateInput(num);  // Invalid input
            }
            catch (InvalidInputException ex)
            {
                Console.WriteLine("Custom Exception Caught:");
                Console.WriteLine(ex.Message);
            }
        }

        static void ValidateInput(int number)
        {
            if (number < 0)
            {
               
                throw new InvalidInputException("Input cannot be negative.");
            }

            Console.WriteLine("Input is valid.");
        }
    }

    public class InvalidInputException : ApplicationException
    {
        // Constructor that accepts a custom error message
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
