using System.Globalization;

namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            bool acceptFlag = false;

            while (!acceptFlag)
            {
                Console.WriteLine("enter some integer");
                int n = int.Parse(Console.ReadLine());
                Console.WriteLine("enter numbers :");
                for (int i = 0; i <= n;i++)
                {
                    i = int.Parse(Console.ReadLine());
                    numbers.Add(i);
                }
                Console.WriteLine("do you want to continue? Y/N");
                string accept = Console.ReadLine().ToUpper();

                if (accept == "Y")
                {
                    acceptFlag = true;
                }
                else
                {
                    acceptFlag = false;
                }
            }

            Console.WriteLine("Number of integers in the list:" + numbers.Count);

            double avg=numbers.Average();
            Console.WriteLine("Average:");
            int middle = (numbers.Count%2==0) ? (numbers.Count/2)+1 : (numbers.Count / 2);
            numbers.Insert(middle, (int)avg);

            Console.WriteLine("List after inserting:");
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

            //remove at 2nd pos

            if (numbers.Count > 1)
            {
                numbers.RemoveAt(1);
            }
            //remove by avg value
            numbers.Remove((int)avg);

            Console.WriteLine("List after removing:");
            foreach (int i in numbers)
            {
                Console.Write(i + " ");
            }
            Console.WriteLine();

        }
    }
}
