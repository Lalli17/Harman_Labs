namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                

                Console.WriteLine("Enter the numerator");
                int numerator = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the denominator");
                int denominator = int.Parse(Console.ReadLine());
                int result = numerator / denominator; // Division operation

                Console.WriteLine($"Result of division: {result}");


                int index = 5;
                int[] num = { 1, 2, 3 };
                int value = num[index];
                Console.WriteLine($"Value at index {index} : {value}");
            }
            catch (IndexOutOfRangeException) 
            {
                Console.WriteLine("Index is out of range for the array");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                Console.WriteLine("Cannot divide by zero. Please provide a non-zero denominator.");
            }
            finally
            {
                Console.WriteLine("Execution of try-catch block is completed");
            }
        }
    }
}
