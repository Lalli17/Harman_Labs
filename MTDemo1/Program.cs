using System.Diagnostics;

namespace MTDemo1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Application started");
            Console.WriteLine($"Main Running in {Thread.CurrentThread.ManagedThreadId}");
            Stopwatch sw = Stopwatch.StartNew();

            M1();
            M2();

            Console.WriteLine($"Time took to complete: {sw.ElapsedMilliseconds}");

            Console.WriteLine("Runnig with Classic Thread class");

            sw = Stopwatch.StartNew();

            ThreadStart ts1 = new ThreadStart(M1);
            Thread t1 = new Thread(ts1);
            t1.Start();

            Thread t2 = new Thread(M2);
            t2.Start();

            t1.Join();
            t2.Join();
            Console.WriteLine($"Time took to complete: {sw.ElapsedMilliseconds}");

            Console.WriteLine("Runnig with TPL Task class");

            sw = Stopwatch.StartNew();

            //ThreadStart ts1 = new ThreadStart(M1);
            Task task1 = new Task(M1);
            task1.Start();

            //Thread t2 = new Thread(M2);
            Task task2 = new Task(M2);
            task2.Start();

            Task.WaitAll(task1, task2);

            Console.WriteLine($"Time took to complete: {sw.ElapsedMilliseconds}");



            Console.WriteLine("Runnig with TPL Parallel class");

            sw = Stopwatch.StartNew();


            Parallel.Invoke(M1, M2);

            Console.WriteLine($"Time took to complete: {sw.ElapsedMilliseconds}");

            Console.WriteLine("Runnig with TPL Parallel class");

            sw = Stopwatch.StartNew();


            Parallel.Invoke(M11, M22);

            Console.WriteLine($"Time took to complete: {sw.ElapsedMilliseconds}");


            Console.WriteLine("end of application");
        }

        static void M1()
        {
            Console.WriteLine($"M1 Running in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }
        static void M2()
        {
            Console.WriteLine($"M2 Running in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }

        static void M11()
        {
            //
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, delegate (int i)
            {
                Console.WriteLine($"M11 Running in {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(1000);
            });
        }
        static void M22()
        {
            //for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"M22 Running in {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(1000);
            });
        }
    }
}
