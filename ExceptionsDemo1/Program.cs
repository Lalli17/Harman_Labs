namespace ExceptionsDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // accept 2 ints, find sum, display and repeat

            while (true)
            {
                try
                {
                    Console.WriteLine("Enter first no:");
                    int fno = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter second no:");
                    int sno = int.Parse(Console.ReadLine());

                    int sum = fno + sno;

                    Console.WriteLine($"The sum of {fno} and {sno} is {sum}");
                    // close db
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Please enter only numbers");
                }
                catch (OverflowException ex)
                {
                    Console.WriteLine("Please enter small numbers");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                } // catch all block
                finally
                {
                    Console.WriteLine("In finally");
                }

            }
        }
    }
}
