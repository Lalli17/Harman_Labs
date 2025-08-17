namespace LinqDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Linq to Objects

            List<int> numbers = new List<int>() { 13, 21, 43, 14, 55, 26, 76, 8, 90 };

            // select all even numbers into another array
            // traditional way

            List<int> evenNumbers = new List<int>();

            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                    evenNumbers.Add(number);
            }

            //foreach (int number in evenNumbers)
            //{
            //    Console.WriteLine(number);
            //}

            // SQL: table: numbers, col: number
            // SQL: select number from numbers where number mod 2 = 0 order by number desc
            // LINQ

            var result = from number in numbers
                         where number % 2 == 0
                         orderby number descending
                         select number;

            foreach (int number in result)
            {
                Console.WriteLine(number);
            }
        }
    }
}
