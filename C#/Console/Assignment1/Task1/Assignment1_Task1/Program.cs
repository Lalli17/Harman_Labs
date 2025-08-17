namespace Assignment1_Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //swapping 2 variables without 3rd variable 
            int a, b;
            Console.WriteLine("enter number 1");
            a=int.Parse(Console.ReadLine());
            Console.WriteLine("enter number 2");
            b=int.Parse(Console.ReadLine());
            Console.WriteLine($"before swap a ={a} b ={b} ");
            a = a + b;
            b = a - b;
            a = a - b;
            Console.WriteLine($"after swap a ={a} b ={b} ");
        }
    }
}
