using System.Collections.Concurrent;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;

namespace MT_DEMO3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LargeData largeData = new LargeData();
            // largeData.Fill();

            // Parallel.Invoke(largeData.Fill, largeData.Fill);

            Task t1 = new Task(largeData.Fill);
            t1.Start();

            Task t2 = Task.Factory.StartNew(largeData.Fill);
           // t2.Start();

            Task.WaitAll(t1,t2);

            Console.WriteLine($"Count:{largeData.Stack.Count}");
        }
    }

    class LargeData
    {
        // public Stack<int> Stack=new Stack<int>();

       public ConcurrentStack<int> Stack = new ConcurrentStack<int>();

        //[MethodImpl(MethodImplOptions.Synchronized)]//to make threads work only when the entire section is critical
        public void Fill()
        {
            for (int i = 0; i < 10000000; i++)
            {
                // Monitor.Enter(this);

                //lock (this)
                //{//lock internally uses the monitor
                    Stack.Push(i);
               // }
               //critical section
               //Monitor.Exit(this);
            }
        }
    }
}
