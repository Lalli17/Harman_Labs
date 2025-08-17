namespace CollectionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // store 5 int values in mem
            int[] numbers = new int[5];
            int[] numbers2 = new int[5] { 1, 2, 3, 4, 5 };
            int[] numbers3 = new int[] { 1, 2, 3, 4, 5 };
            int[] numbers4 = { 1, 2, 3 };

            int[,] numbers2d = new int[3, 3];

            // write
            numbers2d[1, 1] = 50;

            // read
            int data = numbers2d[1, 1];





            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine("Enter number");
                numbers[i] = int.Parse(Console.ReadLine());
            }

            // display
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }

            // read from collection
            foreach (int n in numbers)
            {
                Console.WriteLine(n);
            }

            // find the sum of all numbers
            int sum = 0;
            foreach (int n in numbers)
            {
                sum += n;
            }
            Console.WriteLine(sum);

            sum = numbers.Sum();

            // find the max of all numbers
            int max = numbers.Max();
            int min = numbers.Min();
            double avg = numbers.Average();
            Array.Sort(numbers);

        }
    }
}
