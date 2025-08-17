namespace LinqDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var evens = (from n in numbers
                         where IsEven(n)
                         select n).ToList();

            numbers.Add(10);


            foreach (var e in evens)
            {
                Console.WriteLine(e);
            }
        }

        static bool IsEven(int n)
        {
            Console.WriteLine("In IsEven Method");
            return n % 2 == 0;
        }
    }
}
