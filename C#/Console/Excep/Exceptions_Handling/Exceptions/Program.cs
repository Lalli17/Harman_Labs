namespace Exceptions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //accept 2 ints,find sum,display and repeat

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter the first number");
                    int fno = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter second no:");
                    int sno = int.Parse(Console.ReadLine());

                    int sum = fno + sno;

                    Console.WriteLine($"Sum of {fno} and {sno} = {sum}");
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter integers");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("enter small numbers");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("In finally");
                }
            }
        }
    }
}
