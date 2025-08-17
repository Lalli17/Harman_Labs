namespace Linq_Demo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> number = new List<int>() {1,2,3,4,5,6,7,8,9 };
            var evens=(from n in number
                      where IsEven(n)
                      select n).ToList();// doing this so will not allow the addition of 10 since its been consumed by using to List method
            //its called immediate execution
            //without ToList() evens is Ienumberable that is only an expression
            number.Add(10);

            foreach (var n in evens)
            {
                Console.WriteLine(n);
            }
        }

        static bool IsEven(int n)
        {
            Console.WriteLine("Is even method");
            return n % 2 == 0;
        }
    }
}
