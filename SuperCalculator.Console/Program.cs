using SuperCalculator.Business;

namespace SuperCalculator.Console
{
    internal class Program // SRP - UI
    {
        static void Main(string[] args) // SRP - UI
        {
            // accept two int numbers and find sum, then display also save the result
            int fno;
            int sno;
            int sum;
            // UI Code
            System.Console.WriteLine("Enter First Number");
            fno = int.Parse(System.Console.ReadLine());

            System.Console.WriteLine("Enter Second Number");
            sno = int.Parse(System.Console.ReadLine());

            ICalculator calc = new Calculator();

            sum = calc.FindSum(fno, sno);

            // UI Code
            System.Console.WriteLine($"The sum of {fno} and {sno} is {sum}");

        }


    }


} // UI

