namespace MySecondProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //to find the maximum of 2 numbers
            int a, b;
            Console.WriteLine("enter the number 1");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("enter the number 2");
            b = int.Parse(Console.ReadLine());
            if (a > b)
                Console.WriteLine($"{a} is the maximum");
            else Console.WriteLine($"{b} is the maximum");
        }
    }
}
