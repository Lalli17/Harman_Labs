namespace CollectionsDemo2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // want to store n number of ints

            List<int> numbers = new List<int>(); // Dynamic typed int array
            numbers.Add(1);
            numbers.Add(2);
            numbers.Add(1);
            numbers.Add(4);
            numbers.Add(5);

            numbers.Sort();

            int x = numbers[0];
            numbers.Insert(0, 10);
            // read
            foreach (int i in numbers)
            {
                Console.WriteLine(i);
            }

            // want to add data in sequene and read first come first serve

            Queue<int> q = new Queue<int>(); // add in one end and read from other end
            // add
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            q.Enqueue(50);

            // only read
            int data = q.Peek();
            // read and delete
            data = q.Dequeue();

            Stack<int> stack = new Stack<int>();
            // add
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);

            // soft read
            data = stack.Peek();
            // hard read
            data = stack.Pop();


            HashSet<int> hashSet = new HashSet<int>();
            hashSet.Add(1);
            hashSet.Add(2);
            hashSet.Add(1);
            hashSet.Add(4);
            hashSet.Add(1);

            //SortedList<int> sorted = new System.Collections.Generic.SortedList<int>();

            // key value pairs
            Dictionary<int, string> results = new Dictionary<int, string>();
            // add
            results.Add(111, "Pass");
            results.Add(222, "Fail");


            // read

            string res = results[222];



        }
    }
}
