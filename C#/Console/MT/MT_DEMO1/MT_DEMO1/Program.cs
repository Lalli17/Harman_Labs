using System.Diagnostics;

namespace MT_DEMO1
{
    internal class Program
    {
        static void Main(string[] args)
        {
           Console.WriteLine("Application start");
          Console.WriteLine($"Main running in {Thread.CurrentThread.ManagedThreadId}");
           Stopwatch sw = Stopwatch.StartNew();
            
            M1();
            M2();
            //takes time so we can run parallely so use multiple threads

            Console.WriteLine($"Time took to complete {sw.ElapsedMilliseconds}");
            //classic Multi thread
            Console.WriteLine("Running with classic thread class");
            //doesnt have 0 argument threads 


            sw= Stopwatch.StartNew();

            ThreadStart ts1 = new ThreadStart(M1);// m1 shd be run in seperate thread with multiple times
            Thread t1 = new Thread(ts1);
            //child thread created in the context of the main thread

            t1.Start();

            Thread t2 = new Thread(M2);
            t2 .Start();

            t1.Join();
            t2 .Join();


            Console.WriteLine($"Time took to complete {sw.ElapsedMilliseconds}");


            Console.WriteLine("Running with TPL class");
            //doesnt have 0 argument threads 


            sw = Stopwatch.StartNew();

            Task task1 = new Task(M1);// m1 shd be run in seperate thread with multiple times      
            task1.Start();

            Task task2 = new Task(M2);
            task2.Start();

            Task.WaitAll(task1,task2);


            Console.WriteLine($"Time took to complete {sw.ElapsedMilliseconds}");



            Console.WriteLine("Running with TPL parallel class");
           

            sw = Stopwatch.StartNew();
            Parallel.Invoke(M1, M2);

            Console.WriteLine($"Time took to complete {sw.ElapsedMilliseconds}");




            Console.WriteLine("Running with TPL parallel class");


            sw = Stopwatch.StartNew();
            Parallel.Invoke(M11, M22);
            //within M11 again multiple threads are created
            Console.WriteLine($"Time took to complete {sw.ElapsedMilliseconds}");


            Console.WriteLine("End of Application");
        }

        static void M1()
        {
            Console.WriteLine($"M1 running in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }
        static void M2()
        {
            Console.WriteLine($"M2 running in {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(1000);
            }
        }


        static void M11()
        {
            //for (int i = 0; i < 10; i++)

            Parallel.For(0, 10, delegate (int i)
                {
                    Console.WriteLine($"M11 running in {Thread.CurrentThread.ManagedThreadId}");

                    Thread.Sleep(1000);
                });//execute 10 times in parallely
        }
        static void M22()
        {
            // for (int i = 0; i < 10; i++)
            Parallel.For(0, 10, i =>
            {
                Console.WriteLine($"M22 running in {Thread.CurrentThread.ManagedThreadId}");

                Thread.Sleep(1000);
            });//lambda method
        }

    }
}
