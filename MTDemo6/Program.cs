namespace MTDemo6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"No. Cores : {Environment.ProcessorCount}");

            ParallelOptions options = new ParallelOptions();
            options.MaxDegreeOfParallelism = 2;

            Parallel.For(0, 1000, options, (i) =>
            {
                Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
            });



        }
    }
}
