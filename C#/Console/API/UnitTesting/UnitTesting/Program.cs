namespace UnitTesting
{
    internal class Program
    {
        static void Main(string[] args) //srp ui
        {
            // Console.WriteLine("Hello, World!");
            //accept 2 int numbers and find sum
            int fno;
            int sno;
            int sum;

            //ui code
            Console.WriteLine("enter the first number");
            fno = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the second number");
            sno = int.Parse(Console.ReadLine());
            ICalculator calc = new Calculator();

            sum = calc.FindSum(fno, sno);


            Console.WriteLine($"sum of {fno} + {sno} = {sum}");

        }
    }
}

