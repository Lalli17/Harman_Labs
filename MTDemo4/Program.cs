namespace MTDemo4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(M1);
            Task task1 = new Task(M1);
            Parallel.Invoke(M1);

            //Thread thread2 = new Thread(M2);
            Task task2 = new Task(() => { M2(100); });
            //Parallel.Invoke(M2);

            Task<int> task3 = new Task<int>(() => { return M3(); });
            task3.Start();
            //fsdfsdf
            //sdfsdfsdf
            //sdfsdfsdf
            int result = task3.Result;
            //sdfsdfsdf


            Task<int> task4 = new Task<int>(() => { return M4(100); });
            task4.Start();
            result = task4.Result;
        }

        public static void M1() { }
        public static void M2(int i) { }

        public static int M3() { return 0; }

        public static int M4(int i) { return i; }

    }
}
