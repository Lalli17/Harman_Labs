using System.Globalization;

namespace Collections_Demo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //store 5 int values in mem
            int[] number = new int[5];
            int[] num2 = new int[5] {10,20,30,40,50};
            int[] num3 = new int[] {10,20,30,50};
            int[] num4 = {1,2,3,4,5,6,7};

            int[,] num2d = new int[3, 3];

            //write 2d
            num2d[1, 1] = 50;

            // read
            int data = num2d[1,1];





            Console.WriteLine("enter numbers");
            for (int i = 0; i < number.Length; i++)
            {
                number[i] = int.Parse(Console.ReadLine());

            }
            //diplay uding for - loop
            //for (int i = 0;i < number.Length; i++)
            //{
            //    Console.Write(number[i]+"\t");
            //}

            //read from collections use for each loop
            //sum of all numbers 
            int sum = 0;
            foreach (int n in number)
            {
                sum += n;
                //Console.WriteLine(n);
            }
            Console.WriteLine(sum);

            int sum1 = number.Sum();
            int min=number.Min(); 
            int max=number.Max();
            double avg=number.Average();
            Array.Sort(number);

        }  
    }
}
