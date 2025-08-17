namespace Assignment1_Task2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //accept a string and convert into uppercase and fing its length
            string str;
            Console.WriteLine("Enter a string");
            str = Console.ReadLine();
            Console.WriteLine($"Original string length: {str.Length} Uppercase String : {str.ToUpper()}");
        }
    }
}
