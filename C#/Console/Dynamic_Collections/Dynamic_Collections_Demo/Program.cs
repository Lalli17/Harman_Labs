using System.Collections;
using System.Collections.Concurrent;

namespace Dynamic_Collections_Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
           List<int> list = new List<int>(); //dynamic typed int array
            list.Add(1);
            list.Add(2);
            list.Add(3);    
            list.Add(4);
            list.Add(5);
            list.Add(6);

            int x = list[0];
            list.Insert(0, 10);

            foreach (int i in list)
            {
                Console.WriteLine(i);
            }
            int sum = list.Sum();

            Queue<int> q=new Queue<int>();
            q.Enqueue(10);
            q.Enqueue(20);
            q.Enqueue(30);
            
            int data =q.Dequeue();

            Stack<int> stack = new Stack<int>();
            stack.Push(10);
            stack.Push(20);

            data = stack.Peek();
            data = stack.Pop();

            HashSet<int> set = new HashSet<int>();
            set.Add(1);
            set.Add(2);
            set.Add(3);
            set.Add(4);
            set.Add(5);
            set.Add(1);


            Dictionary<int,string> res = new Dictionary<int,string>();
            res.Add(111, "pass");

            string result = res[111];

            ConcurrentStack<int> ints = new ConcurrentStack<int>();


            //// to read data back
            //int a = list[0];
            
            
            //int[] ints = new int[10];//static typed int array
            //ints[0] = 1;    

            //ArrayList arrayList= new ArrayList(); //Dynamic untyped array
            //arrayList.Add(1);
            //arrayList.Add("2");
            //arrayList.Add(true);

            //int x= (int)arrayList[0];
            //string y= (string)arrayList[1];
            //bool z= (bool)arrayList[2];
        }
    }
}
