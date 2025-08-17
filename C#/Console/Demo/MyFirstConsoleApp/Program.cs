namespace MyFirstConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //accept 2 numbers and find thw sum and then dislay
            int a, b, c;
            Console.WriteLine("enter the number 1");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("enter the number 2");
            b =int.Parse(Console.ReadLine());
            c = a + b;
            Console.WriteLine($"the sum of {a} and {b} = {c}");
        }
        
    }   
}
