namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept 2 numbers and find the sum, then display
            // Step 1: declare variables
            int fno;
            int sno;
            int sum;

            // Step 2: input the data
            Console.WriteLine("Enter first number: ");
            fno = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter second number:");
            sno = int.Parse(Console.ReadLine());

            // Step 3: find the sum
            sum = fno + sno;

            // Step 4: display the result
            Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
        }

    }
}
