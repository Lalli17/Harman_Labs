namespace LINQ_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Link to Objects

            List<int> numbers = new List<int>() { 21, 32, 3, 14, 54, 6, 74, 8, 39 };

            //select all even numbers into another array
            //traditional way

            List<int> evenNumbers = new List<int>();
            foreach (int number in numbers)
            {
                if (number % 2 == 0)
                {
                    evenNumbers.Add(number);
                }
            }
            //foreach (int number in evenNumbers)
            //{
            //    Console.WriteLine(number);
            //}

            //SQL table  numbers, col: number
            //SQL: select number from numbers where number mod 2 = 0
            // LINQ

            var result = from number in numbers
                         where number % 2 == 0
                         orderby number
                         select number;
            foreach (int num in result)
            {
                Console.WriteLine(num);
             }

        }
    }
}
