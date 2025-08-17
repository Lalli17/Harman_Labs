namespace Task4_Queues
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            queue.Enqueue("string1");
            queue.Enqueue("string2");
            queue.Enqueue("string4");
            queue.Enqueue("string5");

            // Step 2: Traverse and print all items
            Console.WriteLine("Original Queue:");
            foreach (var item in queue)
            {
                Console.WriteLine(item);
            }

            // Answer: The first output will be 'string1' because Queue is FIFO

            // Step 3: Insert "string3" between "string2" and "string4"
            Queue<string> modifiedQueue = new Queue<string>();

            while (queue.Count > 0)
            {
                string current = queue.Dequeue();
                modifiedQueue.Enqueue(current);

                if (current == "string2")
                {
                    modifiedQueue.Enqueue("string3");
                }
            }

            // Step 4: Traverse modified queue
            Console.WriteLine("\nModified Queue after inserting 'string3':");
            foreach (var item in modifiedQueue)
            {
                Console.WriteLine(item);
            }

        }
    }
}
