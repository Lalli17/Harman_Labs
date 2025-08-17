using System.Collections.Concurrent;

namespace MTDemo3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LargeData largeData = new LargeData();
            //largeData.Fill();
            //largeData.Fill();
            //Parallel.Invoke(largeData.Fill, largeData.Fill);

            Task t1 = new Task(largeData.Fill);
            t1.Start();
            Task t2 = Task.Factory.StartNew(largeData.Fill);
            //t2.Start();
            Task.WaitAll(t1, t2);
            Console.WriteLine($"Count: {largeData.Stack.Count}");
        }
    }
    class LargeData
    {
        //public Stack<int> Stack = new Stack<int>();
        public ConcurrentStack<int> Stack = new ConcurrentStack<int>();
        //[MethodImpl(MethodImplOptions.Synchronized)]
        public void Fill()
        {
            for (int i = 1; i <= 10000000; i++)
            {
                //Monitor.Enter(this);
                //lock (this)
                //{
                Stack.Push(i);
                //}
                //Monitor.Exit(this);
            }
        }
    }
}
